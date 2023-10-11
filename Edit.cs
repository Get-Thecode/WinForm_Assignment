using Assignment_EmployeeSalaryDetails.Models;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Assignment_EmployeeSalaryDetails
{
    public partial class Edit : Form
    {
        private string employeeCode;
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-JBC2LFT\SQLEXPRESS;Initial Catalog=Employee;Integrated Security=True");
        public Edit(string code)
        {
            InitializeComponent();
            employeeCode = code;
        }

        private void Edit_Load(object sender, EventArgs e)
        {
            
            Employee selectedEmployee = GetEmployeeByCode(employeeCode);

           
            if (selectedEmployee != null)
            {
                string countryName = GetCountryNameWithId(selectedEmployee.Country_Code);
                string stateName = GetStateNameWithId(selectedEmployee.State_Code);
                string cityName = GetCityNameWithId(selectedEmployee.City_Code);


                string deptName = GetDepartmentNameWithId(selectedEmployee.Dept_Code);

                txtCode.Text = selectedEmployee.Code;
                txtFirstName.Text = selectedEmployee.First_Name;
                txtMiddleName.Text = selectedEmployee.Middle_Name;
                txtLastName.Text = selectedEmployee.Last_Name;
                txtFullName.Text = selectedEmployee.Full_Name;
                txtDOB.Value = selectedEmployee.DOB; 
                txtSalary.Text = selectedEmployee.Salary.ToString(); 

               

                // Calculate and display age
                DateTime dateOfBirth = selectedEmployee.DOB;
                DateTime currentDate = DateTime.Now;
                TimeSpan ageTimeSpan = currentDate - dateOfBirth;

                int ageInYears = ageTimeSpan.Days / 365; 
                int ageInMonths = (int)((ageTimeSpan.TotalDays - (ageInYears * 365)) / 30); 
                int ageInDays = (int)(ageTimeSpan.TotalDays % 30); 

                txtAgeYears.Text = ageInYears.ToString();
                txtAgeMonths.Text = ageInMonths.ToString();
                txtAgeDays.Text = ageInDays.ToString();

                txtCountryCode.Text = $" {countryName}";
                txtStateCode.Text = $" {stateName}";
                txtCityCode.Text = $" {cityName}";
                txtDeptCode.Text = $" {deptName}";

                LoadDepartments(txtDeptCode.Text);
                LoadCities(txtCityCode.Text);
                LoadCountries(txtCountryCode.Text);
                LoadStates(txtStateCode.Text);

            }
        }

        public Employee GetEmployeeByCode(string EmployeeCode)
        {
            Employee employee = null;
            
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-JBC2LFT\SQLEXPRESS;Initial Catalog=Employee;Integrated Security=True");


            try
            {
                conn.Open();

                string query = "SELECT * FROM EMP_MAS WHERE Code = @EmployeeCode";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@EmployeeCode", employeeCode);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    
                     employee = new Employee
                    {
                        Code = reader.GetString(reader.GetOrdinal("Code")),
                        First_Name = reader.GetString(reader.GetOrdinal("First_Name")),
                        Middle_Name = reader.IsDBNull(reader.GetOrdinal("Middle_Name")) ? string.Empty : reader.GetString(reader.GetOrdinal("Middle_Name")),
                        Last_Name = reader.IsDBNull(reader.GetOrdinal("Last_Name")) ? string.Empty : reader.GetString(reader.GetOrdinal("Last_Name")),
                        Full_Name = reader.IsDBNull(reader.GetOrdinal("Full_Name")) ? string.Empty : reader.GetString(reader.GetOrdinal("Full_Name")),
                        DOB = reader.GetDateTime(reader.GetOrdinal("DOB")),
                        Salary = reader.GetInt32(reader.GetOrdinal("Salary")),
                        Dept_Code = reader.GetInt32(reader.GetOrdinal("Dept_Code")),
                        
                        Country_Code = reader.GetInt32(reader.GetOrdinal("Country_Code")),
                        State_Code = reader.GetInt32(reader.GetOrdinal("State_Code")),
                        City_Code = reader.GetInt32(reader.GetOrdinal("City_Code")),

                        
                     };

                }

                reader.Close();
            }
            catch (Exception ex)
            {
                
            }
            finally
            {
                // Ensure that the connection is always closed
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }


            return employee;
        }

        public string GetDepartmentNameWithId(int id)
        {
            string departmentName = null;

            
                try
                {
                    conn.Open();

                    using (SqlCommand command = new SqlCommand("GetDepartmentNameWithId", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@p_id", id);
                        command.Parameters.Add("@p_departmentName", SqlDbType.VarChar, 255).Direction = ParameterDirection.Output;

                        command.ExecuteNonQuery();

                        departmentName = command.Parameters["@p_departmentName"].Value.ToString();
                    }
                }
                catch (Exception ex)
                {
                    
                    Console.WriteLine("Error: " + ex.Message);
                }
                finally
                {
                    
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
            

            return departmentName;
        }


        public string GetCountryNameWithId(int id)
        {
            string countryName = null;

           
                try
                {
                    conn.Open();

                    using (SqlCommand command = new SqlCommand("GetCountryNameWithId", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@p_id", id);
                        command.Parameters.Add("@p_countryName", SqlDbType.VarChar, 255).Direction = ParameterDirection.Output;

                        command.ExecuteNonQuery();

                        countryName = command.Parameters["@p_countryName"].Value.ToString();
                    }
                }
                catch (Exception ex)
                {
                    
                    Console.WriteLine("Error: " + ex.Message);
                }
                finally
                {
                    
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
            

            return countryName;
        }


        public string GetCityNameWithId(int id)
        {
            string cityName = null;

           
                try
                {
                    conn.Open();

                    using (SqlCommand command = new SqlCommand("GetCityNameWithId", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@p_id", id);
                        command.Parameters.Add("@p_cityName", SqlDbType.VarChar, 255).Direction = ParameterDirection.Output;

                        command.ExecuteNonQuery();

                        cityName = command.Parameters["@p_cityName"].Value.ToString();
                    }
                }
                catch (Exception ex)
                {
                    
                    Console.WriteLine("Error: " + ex.Message);
                }
                finally
                {
                   
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
            

            return cityName;
        }


        public string GetStateNameWithId(int id)
        {
            string stateName = null;

           
                try
                {
                    conn.Open();

                    using (SqlCommand command = new SqlCommand("GetStateNameWithId", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@p_id", id);
                        command.Parameters.Add("@p_stateName", SqlDbType.VarChar, 255).Direction = ParameterDirection.Output;

                        command.ExecuteNonQuery();

                        stateName = command.Parameters["@p_stateName"].Value.ToString();
                    }
                }
                catch (Exception ex)
                {
                    
                    Console.WriteLine("Error: " + ex.Message);
                }
                finally
                {
                    
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
            

            return stateName;
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.button1_Click(sender, e);
        }
        private void LoadDepartments(string department)
        {
            
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-JBC2LFT\SQLEXPRESS;Initial Catalog=Employee;Integrated Security=True");

            try
            {
                
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT Code, Name FROM DEPT_MAS", conn);

                DataTable table1 = new DataTable();

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(table1);

            
                DataRow defaultRow = table1.NewRow();
                defaultRow["Code"] = 0;
                defaultRow["Name"] = department; // Set a default display name
                table1.Rows.InsertAt(defaultRow, 0);

            
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
                conn.Close();
            }
        }


        private void LoadCities(string city)
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
                defaultRow["Name"] = city; // Set a default display name
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

        private void LoadStates(string state)
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
                defaultRow["Name"] = state; // Set a default display name
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

        private void LoadCountries(string country)
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
                defaultRow["Name"] = country; // Set a default display name
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

        private void button2_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }
    }
}
