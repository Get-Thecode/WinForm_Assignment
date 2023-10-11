using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment_EmployeeSalaryDetails
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
            dataGridViewEmployees.CellContentClick += dataGridViewEmployees_CellContentClick;

        }

        private void Home_Load(object sender, EventArgs e)
        {
            DataTable employeeDataTable = GetEmployeeData(); // Replace with your data retrieval logic

            // Call the method to display employee data in the DataGridView
            DisplayEmployeeData(employeeDataTable);
            AddEditAndDeleteButtonColumns();
        }
        private void DisplayEmployeeData(DataTable employeeDataTable)
        {
            // Create a new DataTable to display the data with S.no
            DataTable displayDataTable = new DataTable();

            // Add columns to the displayDataTable
            displayDataTable.Columns.Add("S.no", typeof(int));
            displayDataTable.Columns.Add("Employee Code", typeof(string));
            displayDataTable.Columns.Add("Full Name", typeof(string));

            // Populate the displayDataTable with data and S.no
            int serialNumber = 1;
            foreach (DataRow employeeRow in employeeDataTable.Rows)
            {
                string employeeCode = employeeRow["Code"].ToString(); // Assuming "Code" is the employee code column
                string fullName = employeeRow["Full_Name"].ToString(); // Assuming "Full_Name" is the full name column

                displayDataTable.Rows.Add(serialNumber, employeeCode, fullName);
                serialNumber++;
            }

            // Bind the displayDataTable to the DataGridView
            dataGridViewEmployees.DataSource = displayDataTable;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Assuming you have a DataTable or List containing employee data
            DataTable employeeDataTable = GetEmployeeData(); // Replace with your data retrieval logic

            // Call the method to display employee data in the DataGridView
            DisplayEmployeeData(employeeDataTable);
        }


        private DataTable GetEmployeeData()
        {
            DataTable dataTable = new DataTable();

            
            // Create a connection to the SQL Server database
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-JBC2LFT\SQLEXPRESS;Initial Catalog=Employee;Integrated Security=True");

           
                conn.Open();

                // Replace the query with your own SQL query to retrieve employee data
                string query = "SELECT Code, Full_Name FROM EMP_MAS";

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            

            return dataTable;
        }
        private void AddEditAndDeleteButtonColumns()
        {
            // Create a DataGridViewButtonColumn for the Edit button
            DataGridViewButtonColumn editButtonColumn = new DataGridViewButtonColumn();
            editButtonColumn.Name = "EditButtonColumn";
            editButtonColumn.HeaderText = "Edit";
            editButtonColumn.Text = "Edit";
            editButtonColumn.UseColumnTextForButtonValue = true;

            // Create a DataGridViewButtonColumn for the Delete button
            DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn();
            deleteButtonColumn.Name = "DeleteButtonColumn";
            deleteButtonColumn.HeaderText = "Delete";
            deleteButtonColumn.Text = "Delete";
            deleteButtonColumn.UseColumnTextForButtonValue = true;

            // Add the columns to the DataGridView
            dataGridViewEmployees.Columns.Add(editButtonColumn);
            dataGridViewEmployees.Columns.Add(deleteButtonColumn);
        }

        private void dataGridViewEmployees_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the clicked cell is in the EditButtonColumn
            if (e.ColumnIndex == dataGridViewEmployees.Columns["EditButtonColumn"].Index && e.RowIndex >= 0)
            {
                // Get the employee code from the selected row in the DataGridView
                string employeeCode = dataGridViewEmployees.Rows[e.RowIndex].Cells["Employee Code"].Value.ToString();

                // Open the Edit form and pass the employee code as a parameter
                Edit editForm = new Edit(employeeCode);
                editForm.ShowDialog(); // Show the Edit form as a dialog
            }
            else if (e.ColumnIndex == dataGridViewEmployees.Columns["DeleteButtonColumn"].Index && e.RowIndex >= 0)
            {
                // Get the employee code from the selected row
                string employeeCode = dataGridViewEmployees.Rows[e.RowIndex].Cells["Employee Code"].Value.ToString();

                // Show a confirmation dialog
                DialogResult result = MessageBox.Show($"Are you sure you want to delete employee {employeeCode}?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    // Call the delete method with the employee code
                    bool deleted = DeleteEmployeeByCode(employeeCode);

                    if (deleted)
                    {
                        // Employee was deleted successfully
                        MessageBox.Show($"Employee {employeeCode} deleted successfully.");


                        dataGridViewEmployees.DataSource = GetEmployeeData(); 
                    }
                    else
                    {
                        MessageBox.Show($"Failed to delete employee {employeeCode}.");
                    }
                }
            }
        }

        public bool DeleteEmployeeByCode(string code)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-JBC2LFT\SQLEXPRESS;Initial Catalog=Employee;Integrated Security=True");
            try
            {
               
                    conn.Open();

                    SqlCommand command = new SqlCommand("DELETE FROM EMP_MAS WHERE Code = @p_Code", conn);

                    // Add the parameter for the employee code
                    command.Parameters.AddWithValue("@p_Code", code);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        // Employee deleted successfully
                        return true;
                    }
                    else
                    {
                        // No employee found with the given code, or delete failed
                        return false;
                    }
                
            }
            catch (Exception ex)
            {
                // Handle any exceptions here, such as connection errors
                // You can log the exception or return an appropriate error message
                return false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 create = new Form1();
            create.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Salary salary = new Salary();
            salary.Show();
            this.Hide();
        }
    }
}
