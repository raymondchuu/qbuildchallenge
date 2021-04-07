using System;
using System.Windows.Forms;

/**
 * Name: Raymond Chu
 * Scope: QBuild Challenge
 * 
 * This C# project is an application that generates visual representation of a Bill of Materials for a Valve part using a treeview and a datagridview to organize and display the data.
 * 
 * Logic: 
 * 1. Generate connection to sql database
 * 2. Button onclick that generates a tree of the materials using the static BOM database
 * 3. Depending on the node selected from the treeview, perform a sql query to search for the child parts of the selected node, and fill datagridview with the required information
 * 
 */

namespace qbuild_coding_challenge
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
