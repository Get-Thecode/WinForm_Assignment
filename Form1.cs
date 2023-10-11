using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Assignment_EmployeeSalaryDetails.Models;

namespace Assignment_EmployeeSalaryDetails
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-JBC2LFT\SQLEXPRESS;Initial Catalog=Employee;Integrated Security=True");

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadDepartments();
            LoadCities();
            LoadCountries();
            LoadStates();
           
        }

        private void LoadDepartments()
        {
            // Create a connection to the SQL Server database
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-JBC2LFT\SQLEXPRESS;Initial Catalog=Employee;Integrated Security=True");

            try
            {
                // Open the database connection
                conn.Open();

                // Create a SqlCommand to execute a SQL query
                SqlCommand cmd = new SqlCommand("SELECT Code, Name FROM DEPT_MAS", conn);

                // Create a DataTable to hold the retrieved data
                DataTable table1 = new DataTable();

                // Create a SqlDataAdapter to fill the DataTable
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                // Fill the DataTable with data from the database
                da.Fill(table1);

                // Create a default item and add it to the DataTable
                DataRow defaultRow = table1.NewRow();
                defaultRow["Code"] = 0;
                defaultRow["Name"] = "Select Department"; // Set a default display name
                table1.Rows.InsertAt(defaultRow, 0);

                // Set the ComboBox data source to the DataTable
                txtDeptCode.DataSource = table1;

                // Set the display member to the column name that should be displayed
                txtDeptCode.DisplayMember = "Name";

                // Set the value member to the column name that holds the underlying value
                txtDeptCode.ValueMember = "Code";

                // Select the default item
                txtDeptCode.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                // Close the database connection
                conn.Close();
            }
        }


        private void LoadCities()
        {
            // Create a connection to the SQL Server database
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-JBC2LFT\SQLEXPRESS;Initial Catalog=Employee;Integrated Security=True");

            try
            {
                // Open the database connection
                conn.Open();

                // Create a SqlCommand to execute a SQL query
                SqlCommand cmd = new SqlCommand("SELECT Code, Name FROM CITY_MAS", conn);

                // Create a DataTable to hold the retrieved data
                DataTable table = new DataTable();

                // Create a SqlDataAdapter to fill the DataTable
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                // Fill the DataTable with data from the database
                da.Fill(table);

                // Create a default item and add it to the DataTable
                DataRow defaultRow = table.NewRow();
                defaultRow["Code"] = 0; // Set an appropriate default code (e.g., -1)
                defaultRow["Name"] = "Select City"; // Set a default display name
                table.Rows.InsertAt(defaultRow, 0);

                // Set the ComboBox data source to the DataTable
                txtCityCode.DataSource = table;

                // Set the display member to the column name that should be displayed
                txtCityCode.DisplayMember = "Name";

                // Set the value member to the column name that holds the underlying value
                txtCityCode.ValueMember = "Code";

                // Select the default item
                txtCityCode.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                // Close the database connection
                conn.Close();
            }
        }

        private void LoadStates()
        {
            // Create a connection to the SQL Server database
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-JBC2LFT\SQLEXPRESS;Initial Catalog=Employee;Integrated Security=True");

            try
            {
                // Open the database connection
                conn.Open();

                // Create a SqlCommand to execute a SQL query
                SqlCommand cmd = new SqlCommand("SELECT Code, Name FROM STATE_MAS", conn);

                // Create a DataTable to hold the retrieved data
                DataTable table = new DataTable();

                // Create a SqlDataAdapter to fill the DataTable
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                // Fill the DataTable with data from the database
                da.Fill(table);

                // Create a default item and add it to the DataTable
                DataRow defaultRow = table.NewRow();
                defaultRow["Code"] = 0; // Set an appropriate default code (e.g., -1)
                defaultRow["Name"] = "Select State"; // Set a default display name
                table.Rows.InsertAt(defaultRow, 0);

                // Set the ComboBox data source to the DataTable
                txtStateCode.DataSource = table;

                // Set the display member to the column name that should be displayed
                txtStateCode.DisplayMember = "Name";

                // Set the value member to the column name that holds the underlying value
                txtStateCode.ValueMember = "Code";

                // Select the default item
                txtStateCode.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                // Close the database connection
                conn.Close();
            }
        }

        private void LoadCountries()
        {
            // Create a connection to the SQL Server database
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-JBC2LFT\SQLEXPRESS;Initial Catalog=Employee;Integrated Security=True");

            try
            {
                // Open the database connection
                conn.Open();

                // Create a SqlCommand to execute a SQL query
                SqlCommand cmd = new SqlCommand("SELECT Code, Name FROM COUNTRY_MAS", conn);

                // Create a DataTable to hold the retrieved data
                DataTable table = new DataTable();

                // Create a SqlDataAdapter to fill the DataTable
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                // Fill the DataTable with data from the database
                da.Fill(table);

                // Create a default item and add it to the DataTable
                DataRow defaultRow = table.NewRow();
                defaultRow["Code"] = 0; // Set an appropriate default code (e.g., -1)
                defaultRow["Name"] = "Select Country"; // Set a default display name
                table.Rows.InsertAt(defaultRow, 0);

                // Set the ComboBox data source to the DataTable
                txtCountryCode.DataSource = table;

                // Set the display member to the column name that should be displayed
                txtCountryCode.DisplayMember = "Name";

                // Set the value member to the column name that holds the underlying value
                txtCountryCode.ValueMember = "Code";

                // Select the default item
                txtCountryCode.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                // Close the database connection
                conn.Close();
            }
        }

        public void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Get values from your form's controls
                string firstName = txtFirstName.Text;
                string middleName = txtMiddleName.Text;
                string lastName = txtLastName.Text;
                string fullName = txtFullName.Text;
                DateTime dob = Convert.ToDateTime(txtDOB.Text);
                int salary = Convert.ToInt32(txtSalary.Text);
                // Get the selected department code from the ComboBox
                int deptCode = (int)txtDeptCode.SelectedValue;

                // Get the selected country code from the ComboBox
                int countryCode = (int)txtCountryCode.SelectedValue;

                // Get the selected state code from the ComboBox
                int stateCode = (int)txtStateCode.SelectedValue;

                // Get the selected city code from the ComboBox
                int cityCode = (int)txtCityCode.SelectedValue;

                // Define the prefix (you can modify this as needed)
                string prefix = txtCode.Text;

                // Initialize the postfix
                int postfix = 1;

                // Generate the initial code
                string generatedCode = $"{prefix} {postfix:D3}";

                // Check if the generated code already exists in the database
                while (EmployeeCodeExists(generatedCode))
                {
                    // If it exists, increment the postfix and regenerate the code
                    postfix++;
                    generatedCode = $"{prefix} {postfix:D3}";
                }

                // Set the generated code as the employee's code
                string code = generatedCode; // Use the postfix as the code

                // Define your SQL query with parameters
                string sqlQuery = "INSERT INTO EMP_MAS (Code, First_Name, Middle_Name, Last_Name, Full_Name, DOB, Salary, Dept_Code, Country_Code, State_Code, City_Code) " +
                                  "VALUES (@Code, @FirstName, @MiddleName, @LastName, @FullName, @DOB, @Salary, @DeptCode, @CountryCode, @StateCode, @CityCode)";

                using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-JBC2LFT\SQLEXPRESS;Initial Catalog=Employee;Integrated Security=True"))
                using (SqlCommand cmd = new SqlCommand(sqlQuery, conn))
                {
                    // Add parameters
                    cmd.Parameters.AddWithValue("@Code", code);
                    cmd.Parameters.AddWithValue("@FirstName", firstName);
                    cmd.Parameters.AddWithValue("@MiddleName", middleName);
                    cmd.Parameters.AddWithValue("@LastName", lastName);
                    cmd.Parameters.AddWithValue("@FullName", fullName);
                    cmd.Parameters.AddWithValue("@DOB", dob);
                    cmd.Parameters.AddWithValue("@Salary", salary);
                    cmd.Parameters.AddWithValue("@DeptCode", deptCode);
                    cmd.Parameters.AddWithValue("@CountryCode", countryCode);
                    cmd.Parameters.AddWithValue("@StateCode", stateCode);
                    cmd.Parameters.AddWithValue("@CityCode", cityCode);

                    // Open the connection and execute the query
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee data inserted successfully!");
                    Home home = new Home();
                    home.Show();
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void txtDOB_ValueChanged(object sender, EventArgs e)
        {
            if (DateTime.TryParse(txtDOB.Text, out DateTime selectedDate))
            {
                DateTime today = DateTime.Today;
                DateTime minDate = today.AddYears(-18);

                if (selectedDate > minDate)
                {
                    MessageBox.Show("You must be at least 18 years old.");
                    // You can clear or reset the date here if needed.
                    txtDOB.Text = minDate.ToString("yyyy-MM-dd"); // Set the date to the minimum allowed date
                }
            }
            else
            {
                MessageBox.Show("Invalid date format. Please enter a valid date (YYYY-MM-DD).");
                // You can clear or reset the date here if needed.
                txtDOB.Text = ""; // Clear the TextBox if the date is not in a valid format
            }
        }

        private void GenerateCode()
        {
            string firstName = txtFirstName.Text;
            string middleName = txtMiddleName.Text;
            string lastName = txtLastName.Text;

            // Initialize the code variable
            string code = "";

            // Extract the first letter of each name (if available) and concatenate them
            if (!string.IsNullOrEmpty(firstName))
            {
                code += firstName[0].ToString().ToUpper();
            }
            if (!string.IsNullOrEmpty(middleName))
            {
                code += middleName[0].ToString().ToUpper();
            }
            if (!string.IsNullOrEmpty(lastName))
            {
                code += lastName[0].ToString().ToUpper();
            }

            // Set the generated code in the "Code" TextBox
            txtCode.Text = code;
        }

        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {
            GenerateCode();
        }

        private void txtMiddleName_TextChanged(object sender, EventArgs e)
        {
            GenerateCode();
        }

        private void txtLastName_TextChanged(object sender, EventArgs e)
        {
            GenerateCode();
        }

        private void txtCode_TextChanged(object sender, EventArgs e)
        {
            txtCode.ReadOnly = true;

        }
        private void MergeNames()
        {
            string firstName = txtFirstName.Text;
            string middleName = txtMiddleName.Text;
            string lastName = txtLastName.Text;

            // Initialize the full name variable
            string fullName = "";

            // Concatenate the names with spaces (if available)
            if (!string.IsNullOrEmpty(firstName))
            {
                fullName += firstName;
            }
            if (!string.IsNullOrEmpty(middleName))
            {
                fullName += (!string.IsNullOrEmpty(fullName) ? " " : "") + middleName;
            }
            if (!string.IsNullOrEmpty(lastName))
            {
                fullName += (!string.IsNullOrEmpty(fullName) ? " " : "") + lastName;
            }

            // Set the merged full name in the "Full_Name" TextBox
            txtFullName.Text = fullName;
        }

        private void txtFullName_TextChanged(object sender, EventArgs e)
        {
            MergeNames();
            txtFullName.ReadOnly = true;
        }

        // Method to check if an employee code exists in the database
        private bool EmployeeCodeExists(string code)
        {
            // Define your SQL query to check if the code exists
            string sqlQuery = "SELECT COUNT(*) FROM EMP_MAS WHERE Code = @Code";

            using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-JBC2LFT\SQLEXPRESS;Initial Catalog=Employee;Integrated Security=True"))
            using (SqlCommand cmd = new SqlCommand(sqlQuery, conn))
            {
                // Add the parameter for the code
                cmd.Parameters.AddWithValue("@Code", code);

                // Open the connection and execute the query
                conn.Open();

                // Execute the query and get the count result
                int count = Convert.ToInt32(cmd.ExecuteScalar());

                // If the count is greater than 0, the code exists; otherwise, it doesn't
                return count > 0;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }
    }
}
