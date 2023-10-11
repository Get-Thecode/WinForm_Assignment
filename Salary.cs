using Assignment_EmployeeSalaryDetails.Models;
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
    public partial class Salary : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-JBC2LFT\SQLEXPRESS;Initial Catalog=Employee;Integrated Security=True");

        // Declare class-level variables to store values
        private string value1;
        private string value2;

        public Salary()
        {
            InitializeComponent();

            // Assign values to value1 and value2 (replace with your actual values)
            value1 = "SomeValue1";
            value2 = "SomeValue2";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedDepartment = comboBox1.SelectedItem.ToString();

            if (selectedDepartment == "City Wise")
            {
                // Load City Statistics
                LoadCityStatistics();
            }
            else if (selectedDepartment == "Department Wise")
            {
                // Load Department Statistics
                LoadDepartmentStatistics();
            }

        }

        private void LoadStaticDepartments()
        {
            try
            {
                // Create a list of department names
                List<string> departmentNames = new List<string>
                {
                    "Select Option",
                    "City Wise",
                    "Department Wise"
                    
                };

                // Set the ComboBox data source to the list of department names
                comboBox1.DataSource = departmentNames;

                // Select the default item
                comboBox1.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void LoadCityStatistics()
        {
            List<CityStatisticsViewModel> cityStatistics = GetCityStatistics();

            // Assuming you have a DataGridView control named 'dataGridViewCityStatistics'
            DataGridSalary.DataSource = cityStatistics;
        }

        private void LoadDepartmentStatistics()
        {
            List<DepartmentStatisticsViewModel> departmentStatistics = GetDepartmentStatistics();

            // Assuming you have a DataGridView control named 'dataGridViewDepartmentStatistics'
            DataGridSalary.DataSource = departmentStatistics;
        }


        private void Salary_Load(object sender, EventArgs e)
        {
            LoadStaticDepartments();
        }

        public List<CityStatisticsViewModel> GetCityStatistics()
        {
            string query = @"
        SELECT CITY_MAS.Name AS City,
               SUM(EMP_MAS.Salary) AS TotalSalary,
               COUNT(EMP_MAS.Code) AS EmployeeCount
        FROM EMP_MAS
        INNER JOIN CITY_MAS ON EMP_MAS.City_Code = CITY_MAS.Code
        GROUP BY CITY_MAS.Name;";

            return ExecuteQuery(query);
        }

        public List<DepartmentStatisticsViewModel> GetDepartmentStatistics()
        {
            string query = @"
        SELECT DEPT_MAS.Name AS Department,
               SUM(EMP_MAS.Salary) AS TotalSalary,
               COUNT(EMP_MAS.Code) AS EmployeeCount
        FROM EMP_MAS
        INNER JOIN DEPT_MAS ON EMP_MAS.Dept_Code = DEPT_MAS.Code
        GROUP BY DEPT_MAS.Name;";

            return DepExecuteQuery(query);
        }

        private List<CityStatisticsViewModel> ExecuteQuery(string query)
        {
            List<CityStatisticsViewModel> cityStatistics = new List<CityStatisticsViewModel>();

            try
            {
                conn.Open();

                using (var command = new SqlCommand(query, conn))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CityStatisticsViewModel cityStat = new CityStatisticsViewModel
                            {
                                Name = reader["City"].ToString(),
                                TotalSalary = Convert.ToInt32(reader["TotalSalary"]),
                                EmployeeCount = Convert.ToInt32(reader["EmployeeCount"])
                            };
                            cityStatistics.Add(cityStat);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                // Close the connection in the 'finally' block to ensure it's always closed
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }

            return cityStatistics;
        }


        private List<DepartmentStatisticsViewModel> DepExecuteQuery(string query)
        {
            List<DepartmentStatisticsViewModel> depStatistics = new List<DepartmentStatisticsViewModel>();

           

            try
            {
                conn.Open();

                using (var command = new SqlCommand(query, conn))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DepartmentStatisticsViewModel depStat = new DepartmentStatisticsViewModel
                            {
                                Name = reader["Department"].ToString(),
                                TotalSalary = Convert.ToInt32(reader["TotalSalary"]),
                                EmployeeCount = Convert.ToInt32(reader["EmployeeCount"])
                            };
                            depStatistics.Add(depStat);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                // Close the connection in the 'finally' block to ensure it's always closed
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }

            return depStatistics;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }
    }
}
