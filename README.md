# QBuild Challenge
This project was coded in C# and generates a treeview and datagridview to organize and display data from a SQL database.

## Final Product
![Image of Final Product](https://github.com/raymondchuu/qbuildchallenge/blob/master/images/qbuildchallengeapp.png)

## Problem
I received two csv data files in which I was tasked to manipulate these data files to first generate a treeview list of the data within the Bill of Materials (BOM). Once the treeview was completed, I needed to add a datagridview that shows the component parts of the part that is currently selected in the treeview.

## Analysis
Having proficiency in C++ and Java, this was a fun challenge to tackle and it was a great learning experience to educate myself more upon C# my knowledge. To generate the treeview, my plan was to make a SQL query to get all the records from the BOM table, and use a dictionary to efficiently build a tree from the root of tree where the root is the component name with no parent component. 

My plan for the datagridview was so that when the user selects a node on the treeview, a function will make an SQL query to the database to perform a left join and retrieve the records that match according to what the user has selected. I also plan on having a single SQL connection that's open in the beginning and closes when the application closes. The purpose of this single SQL connection is so that everytime a user selects a treeview node, it's a dynamic query to the database as we do not know what the user will select. Making a new connection every time a user selects a node was redundant, therefore I decided to use a single connection. 

## Solution
I essentially needed to build a tree using the BOM data file. I first imported both csv files as tables into a local database file where I can then leverage C# SqlClient library to make sql queries to manipulate the data. To build the treeview, I needed to first find the root node of the datafile, and store the component name as the key in a dictionary and it's value is a list of treenodes. I decided to use a list of treenodes in case that there were multiple components with the same names, but with different parents. Once I added my root in the hash map, I just leveraged SqlClient to obtain all the records within the BOM table, and for each record, I added the component name into my hash map, and instantiated a treenode into the list of treenodes. Then I would search the dictionary to see if the parent node is in the dictionary where if it is, then it will append the current node as a child node of the parent node. This builds my treeview structure.

When the user clicks a node on the treeview, a datagridview displays more data about the children parts of the selected node. I also leveraged SqlClient to make a query in the database. I decided to use left join within my sql query because I needed all the data records from my left table (BOM table). To prevent multiple new SqlConnection instantiations, I decided to instantiate and open an sql connection at the start of the application that remains open throughout the entire life of the application. Every time a user clicks the treenode for more information, the SQL query is made on just one connection and this avoids multiple redundant new SQL connections. The connection is then closed when the user exits out of the application. 
