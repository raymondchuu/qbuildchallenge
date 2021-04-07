using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace qbuild_coding_challenge
{
    public partial class Form1 : Form
    {
        // global sql connection that remains open throughout the life of application
        // csv files were imported using sql server
        private SqlConnection conn = null;

        // constructor to initialize this component
        public Form1()
        {
            InitializeComponent();
        }
        
        // creates a new sql connection and opens it before the form is displayed for the first time to use for the datagridview
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                conn = new SqlConnection(getConnectionString()); // makes connection with local database file
                conn.Open();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.ExitThread(); // exits program if there is an error with connection
            }
        }

        // returns the connection string so that this project can run anywhere as long as database file is within this project directory
        static private string getConnectionString()
        {
            // current WORKING directory (i.e. \bin\debug)
            string workingDirectory = Environment.CurrentDirectory;

            // current PROJECT directory, which is what I need
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;

            return "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + projectDirectory + "\\QbuildParts.mdf;Integrated Security=True;Connect Timeout=30;";
        }

        // onclick event handler to generate the treeview
        private void popTreeDataBtn_Click(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear(); // clears any previous nodes from treeview in case there were any

            // makes a temporary local sql connection just to query the bom table to generate the tree
            using (SqlConnection treeConn = new SqlConnection(getConnectionString()))
            try
            {
                treeConn.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT COMPONENT_NAME, PARENT_NAME FROM BOM", treeConn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    string rootName = findRootNode(); // returns the component name of the root node (VALVE)
                    TreeNode root = new TreeNode(rootName); // create a treenode for the root node

                    // hashmap to store the component name as a key, and list of treenodes as value to store nodes of duplicate components with different parents
                    Dictionary<string, List<TreeNode>> parts = new Dictionary<string, List<TreeNode>>();
                        parts.Add(rootName, new List<TreeNode>()); // add root's component name as the key and initialize treenode list as value
                        parts[rootName].Add(root); // add the root treenode to the list

                    while (reader.Read())
                    {
                        string compName = reader["COMPONENT_NAME"].ToString(); // component name
                        string parentName = reader["PARENT_NAME"].ToString(); // parent name

                        // dont need root value anymore
                        if (!parentName.Equals(""))
                        {
                            // check if component exists in hashmap, and adds to hashmap if it's not in yet
                            if (!parts.ContainsKey(compName))
                            {
                                parts.Add(compName, new List<TreeNode>());
                            }

                            // instantiate new treenode for the component and adds to the list
                            parts[compName].Add(new TreeNode(compName));

                            // searches hashmap for the parent node, and appends it as a child to the parent node
                            // new nodes are pushed to the end of the list, so we always add the most recent node to append to the previous node
                            parts[parentName].Last().Nodes.Add(parts[compName].Last());
                        }
                    }

                    treeView1.Nodes.Add(root); // add root of generated tree to treeview

                    // disables click button after the rows of query has been read
                    if (reader.Read() == false)
                    {
                        popTreeDataBtn.Enabled = false;
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.ExitThread();
            }
        }

        // performs sql query to find the root node of the data and returns the component name of root node
        private static string findRootNode()
        {
            using (SqlConnection rootConn = new SqlConnection(getConnectionString()))
            {
                rootConn.Open();

                string root = "";

                // root node will not have parent name
                string rootQuery = "SELECT COMPONENT_NAME FROM BOM WHERE PARENT_NAME=''";

                SqlCommand findRoot = new SqlCommand(rootQuery, rootConn);
                SqlDataReader reader = findRoot.ExecuteReader();

                if (reader.Read())
                {
                    root = reader["COMPONENT_NAME"].ToString();
                }

                reader.Close();

                return root;
            }

        }

        // event that triggers after selecting node on treeview, and updates the datagridview
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // sql query string to search for the child components of the node being selected on the tree
            string sqlSearchParts = "SELECT BOM.PARENT_NAME, BOM.COMPONENT_NAME, PART.PART_NUMBER, PART.TITLE, BOM.QUANTITY, PART.TYPE, PART.ITEM, PART.MATERIAL FROM BOM LEFT JOIN PART ON BOM.COMPONENT_NAME = PART.NAME WHERE BOM.PARENT_NAME = @parentName";

            partPathLabel.Text = "Parent Child Part: " + treeView1.SelectedNode.FullPath; // updates label to view the parent/child of the part
            currPartLabel.Text = "Current part: " + treeView1.SelectedNode.Text; // updates the label to view the current part selected

            // uses the connection that was opened when the form loaded so that a new connection isn't being used upon every click of a new node
            using (SqlDataAdapter adapter = new SqlDataAdapter(sqlSearchParts, conn))
            {
                // generate datagridview
                adapter.SelectCommand.Parameters.AddWithValue("@parentName", treeView1.SelectedNode.Text); // prevents sql injection
                DataTable dt = new DataTable();
                adapter.Fill(dt); // fills datatable with the sql query result
                dataGridView1.DataSource = dt; // updates datagridview with the datatable
            }
        }

        // button onclick handler that closes the sql connection, and then closes the application
        private void exitBtn_Click(object sender, EventArgs e)
        {
            conn.Close();
            Application.ExitThread();
        }
    }
}