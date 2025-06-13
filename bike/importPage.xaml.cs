using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.Extensions.Configuration;

namespace bike
{
    public partial class importPage : Window
    {
        // Method to create connection using IConfiguration
        public SqlConnection connection()
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("sitting.json").Build();
            SqlConnection conn = new SqlConnection(configuration.GetSection("constr").Value);
            return conn;
        }

        public importPage()
        {
            InitializeComponent();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                this.WindowState = WindowState.Normal;
            }
        }

        private void TextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            // Handle text changes if needed
        }

        // Method to handle price calculation before tax
        //private void CalculatePriceBeforeTax(object sender, RoutedEventArgs e)
        //{
        //    // Read the input values from the TextBoxes
        //    decimal totalGoodsCost = Convert.ToDecimal(TotalGoodsCostTextBox.Text);
        //    decimal shippingCosts = Convert.ToDecimal(ShippingCostsTextBox.Text);
        //    decimal insuranceRate = Convert.ToDecimal(InsuranceRateTextBox.Text);
        //    decimal customsDutyRate = Convert.ToDecimal(CustomsDutyRateTextBox.Text);
        //    decimal exchangeRate = Convert.ToDecimal(ExchangeRateTextBox.Text);
        //    decimal localCosts = Convert.ToDecimal(LocalCostsTextBox.Text);
        //    int numShippedUnits = Convert.ToInt32(NumShippedUnitsTextBox.Text);
        //    decimal profitMargin = Convert.ToDecimal(ProfitMarginTextBox.Text);
        //    decimal vat = Convert.ToDecimal(VATTextBox.Text);

        //    decimal priceBeforeTax = 0;
        //    decimal priceAfterTax = 0;

        //    using (SqlConnection conn = connection())
        //    {
        //        try
        //        {
        //            conn.Open();
        //            using (SqlCommand cmd = new SqlCommand("importOpration", conn))
        //            {
        //                cmd.CommandType = CommandType.StoredProcedure;

        //                // Define an array for the parameters
        //                SqlParameter[] pram = new SqlParameter[10];

        //                pram[0] = new SqlParameter("@costOfAllGoods", SqlDbType.Decimal);
        //                pram[0].Value = totalGoodsCost;

        //                pram[1] = new SqlParameter("@costOfShipping", SqlDbType.Decimal);
        //                pram[1].Value = shippingCosts;

        //                pram[2] = new SqlParameter("@insuranceRate", SqlDbType.Decimal);
        //                pram[2].Value = insuranceRate;

        //                pram[3] = new SqlParameter("@customsRate", SqlDbType.Decimal);
        //                pram[3].Value = customsDutyRate;

        //                pram[4] = new SqlParameter("@exchangeRate", SqlDbType.Decimal);
        //                pram[4].Value = exchangeRate;

        //                pram[5] = new SqlParameter("@localExpenses", SqlDbType.Decimal);
        //                pram[5].Value = localCosts;

        //                pram[6] = new SqlParameter("@countOfPillInshipment", SqlDbType.Int);
        //                pram[6].Value = numShippedUnits;

        //                pram[7] = new SqlParameter("@profitPercentage", SqlDbType.Decimal);
        //                pram[7].Value = profitMargin;

        //                pram[8] = new SqlParameter("@taxPercentage", SqlDbType.Decimal);
        //                pram[8].Value = vat;

        //                // Output parameters for price calculation
        //                pram[9] = new SqlParameter("@priceBeforeTax", SqlDbType.Decimal)
        //                {
        //                    Direction = ParameterDirection.Output,
        //                    Size = 10
        //                };

        //                pram[10] = new SqlParameter("@priceAfterTax", SqlDbType.Decimal)
        //                {
        //                    Direction = ParameterDirection.Output,
        //                    Size = 10
        //                };

        //                // Add the parameters to the command
        //                cmd.Parameters.AddRange(pram);

        //                // Execute the stored procedure
        //                cmd.ExecuteNonQuery();

        //                // Retrieve the calculated prices
        //                priceBeforeTax = (decimal)pram[9].Value;
        //                priceAfterTax = (decimal)pram[10].Value;

        //                // Display the results in TextBlocks
        //                PriceBeforeTaxTextBlock.Text = $"Price Before Tax: {priceBeforeTax:C}";
        //                PriceAfterTaxTextBlock.Text = $"Price After Tax: {priceAfterTax:C}";
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show($"Error: {ex.Message}");
        //        }
        //    }
        //}

        //// Method to handle price calculation after tax (Button_Click1)
        //private void CalculatePriceAfterTax(object sender, RoutedEventArgs e)
        //{
        //    // Read the input values from the TextBoxes
        //    decimal totalGoodsCost = Convert.ToDecimal(TotalGoodsCostTextBox.Text);
        //    decimal shippingCosts = Convert.ToDecimal(ShippingCostsTextBox.Text);
        //    decimal insuranceRate = Convert.ToDecimal(InsuranceRateTextBox.Text);
        //    decimal customsDutyRate = Convert.ToDecimal(CustomsDutyRateTextBox.Text);
        //    decimal exchangeRate = Convert.ToDecimal(ExchangeRateTextBox.Text);
        //    decimal localCosts = Convert.ToDecimal(LocalCostsTextBox.Text);
        //    int numShippedUnits = Convert.ToInt32(NumShippedUnitsTextBox.Text);
        //    decimal profitMargin = Convert.ToDecimal(ProfitMarginTextBox.Text);
        //    decimal vat = Convert.ToDecimal(VATTextBox.Text);

        //    decimal priceAfterTax = 0;

        //    using (SqlConnection conn = connection())
        //    {
        //        try
        //        {
        //            conn.Open();
        //            using (SqlCommand cmd = new SqlCommand("importOpration", conn))
        //            {
        //                cmd.CommandType = CommandType.StoredProcedure;

        //                // Define an array for the parameters
        //                SqlParameter[] pram = new SqlParameter[10];

        //                pram[0] = new SqlParameter("@costOfAllGoods", SqlDbType.Decimal);
        //                pram[0].Value = totalGoodsCost;

        //                pram[1] = new SqlParameter("@costOfShipping", SqlDbType.Decimal);
        //                pram[1].Value = shippingCosts;

        //                pram[2] = new SqlParameter("@insuranceRate", SqlDbType.Decimal);
        //                pram[2].Value = insuranceRate;

        //                pram[3] = new SqlParameter("@customsRate", SqlDbType.Decimal);
        //                pram[3].Value = customsDutyRate;

        //                pram[4] = new SqlParameter("@exchangeRate", SqlDbType.Decimal);
        //                pram[4].Value = exchangeRate;

        //                pram[5] = new SqlParameter("@localExpenses", SqlDbType.Decimal);
        //                pram[5].Value = localCosts;

        //                pram[6] = new SqlParameter("@countOfPillInshipment", SqlDbType.Int);
        //                pram[6].Value = numShippedUnits;

        //                pram[7] = new SqlParameter("@profitPercentage", SqlDbType.Decimal);
        //                pram[7].Value = profitMargin;

        //                pram[8] = new SqlParameter("@taxPercentage", SqlDbType.Decimal);
        //                pram[8].Value = vat;

        //                // Output parameter for price after tax
        //                pram[9] = new SqlParameter("@priceAfterTax", SqlDbType.Decimal)
        //                {
        //                    Direction = ParameterDirection.Output,
        //                    Size = 10
        //                };

        //                // Add the parameters to the command
        //                cmd.Parameters.AddRange(pram);

        //                // Execute the stored procedure
        //                cmd.ExecuteNonQuery();

        //                // Retrieve the calculated price after tax
        //                priceAfterTax = (decimal)pram[9].Value;

        //                // Display the result in the TextBlock
        //                PriceAfterTaxTextBlock.Text = $"Price After Tax: {priceAfterTax:C}";
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show($"Error: {ex.Message}");
        //        }
        //    }
        //}

        // Button click event for triggering price calculation before tax
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Read the input values from the TextBoxes
            decimal totalGoodsCost = Convert.ToDecimal(TotalGoodsCostTextBox.Text);
            decimal shippingCosts = Convert.ToDecimal(ShippingCostsTextBox.Text);
            decimal insuranceRate = Convert.ToDecimal(InsuranceRateTextBox.Text);
            decimal customsDutyRate = Convert.ToDecimal(CustomsDutyRateTextBox.Text);
            decimal exchangeRate = Convert.ToDecimal(ExchangeRateTextBox.Text);
            decimal localCosts = Convert.ToDecimal(LocalCostsTextBox.Text);
            int numShippedUnits = Convert.ToInt32(NumShippedUnitsTextBox.Text);
            decimal profitMargin = Convert.ToDecimal(ProfitMarginTextBox.Text);
            decimal vat = Convert.ToDecimal(VATTextBox.Text);

            decimal priceBeforeTax = 0;
            decimal priceAfterTax = 0;

            using (SqlConnection conn = connection())
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("importOpration", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Define an array for the parameters
                        SqlParameter[] pram = new SqlParameter[11];

                        pram[0] = new SqlParameter("@costOfAllGoods", SqlDbType.Decimal) { Precision = 18, Scale = 2, Value = totalGoodsCost };
                        pram[1] = new SqlParameter("@costOfShipping", SqlDbType.Decimal) { Precision = 18, Scale = 2, Value = shippingCosts };
                        pram[2] = new SqlParameter("@insuranceRate", SqlDbType.Decimal) { Precision = 18, Scale = 2, Value = insuranceRate };
                        pram[3] = new SqlParameter("@customsRate", SqlDbType.Decimal) { Precision = 18, Scale = 2, Value = customsDutyRate };
                        pram[4] = new SqlParameter("@exchangeRate", SqlDbType.Decimal) { Precision = 18, Scale = 2, Value = exchangeRate };
                        pram[5] = new SqlParameter("@localExpenses", SqlDbType.Decimal) { Precision = 18, Scale = 2, Value = localCosts };
                        pram[6] = new SqlParameter("@countOfPillInshipment", SqlDbType.Int) { Value = numShippedUnits };
                        pram[7] = new SqlParameter("@profitPercentage", SqlDbType.Decimal) { Precision = 18, Scale = 2, Value = profitMargin };
                        pram[8] = new SqlParameter("@taxPercentage", SqlDbType.Decimal) { Precision = 18, Scale = 2, Value = vat };

                        pram[9] = new SqlParameter("@priceBeforeTax", SqlDbType.Decimal)
                        {
                            Precision = 18,
                            Scale = 2,
                            Direction = ParameterDirection.Output
                        };

                        pram[10] = new SqlParameter("@priceAfterTax", SqlDbType.Decimal)
                        {
                            Precision = 18,
                            Scale = 2,
                            Direction = ParameterDirection.Output
                        };

                        // Add the parameters to the command
                        cmd.Parameters.AddRange(pram);

                        // Execute the stored procedure
                        cmd.ExecuteNonQuery();

                        // Retrieve the calculated prices
                        priceBeforeTax = (decimal)pram[9].Value;
                        priceAfterTax = (decimal)pram[10].Value;

                        // Display the results in TextBlocks
                        PriceBeforeTaxTextBlock.Text = $"Price Before Tax: {priceBeforeTax:C}";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }

        // Button click event for triggering price calculation after tax (Button_Click1)
        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            // Read the input values from the TextBoxes
            decimal totalGoodsCost = Convert.ToDecimal(TotalGoodsCostTextBox.Text);
            decimal shippingCosts = Convert.ToDecimal(ShippingCostsTextBox.Text);
            decimal insuranceRate = Convert.ToDecimal(InsuranceRateTextBox.Text);
            decimal customsDutyRate = Convert.ToDecimal(CustomsDutyRateTextBox.Text);
            decimal exchangeRate = Convert.ToDecimal(ExchangeRateTextBox.Text);
            decimal localCosts = Convert.ToDecimal(LocalCostsTextBox.Text);
            int numShippedUnits = Convert.ToInt32(NumShippedUnitsTextBox.Text);
            decimal profitMargin = Convert.ToDecimal(ProfitMarginTextBox.Text);
            decimal vat = Convert.ToDecimal(VATTextBox.Text);

            decimal priceAfterTax = 0;

            using (SqlConnection conn = connection())
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("importOpration", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Define an array for the parameters
                        SqlParameter[] pram = new SqlParameter[11];

                        pram[0] = new SqlParameter("@costOfAllGoods", SqlDbType.Decimal) { Precision = 18, Scale = 2, Value = totalGoodsCost };
                        pram[1] = new SqlParameter("@costOfShipping", SqlDbType.Decimal) { Precision = 18, Scale = 2, Value = shippingCosts };
                        pram[2] = new SqlParameter("@insuranceRate", SqlDbType.Decimal) { Precision = 18, Scale = 2, Value = insuranceRate };
                        pram[3] = new SqlParameter("@customsRate", SqlDbType.Decimal) { Precision = 18, Scale = 2, Value = customsDutyRate };
                        pram[4] = new SqlParameter("@exchangeRate", SqlDbType.Decimal) { Precision = 18, Scale = 2, Value = exchangeRate };
                        pram[5] = new SqlParameter("@localExpenses", SqlDbType.Decimal) { Precision = 18, Scale = 2, Value = localCosts };
                        pram[6] = new SqlParameter("@countOfPillInshipment", SqlDbType.Int) { Value = numShippedUnits };
                        pram[7] = new SqlParameter("@profitPercentage", SqlDbType.Decimal) { Precision = 18, Scale = 2, Value = profitMargin };
                        pram[8] = new SqlParameter("@taxPercentage", SqlDbType.Decimal) { Precision = 18, Scale = 2, Value = vat };

                        pram[9] = new SqlParameter("@priceBeforeTax", SqlDbType.Decimal)
                        {
                            Precision = 18,
                            Scale = 2,
                            Direction = ParameterDirection.Output
                        };

                        pram[10] = new SqlParameter("@priceAfterTax", SqlDbType.Decimal)
                        {
                            Precision = 18,
                            Scale = 2,
                            Direction = ParameterDirection.Output
                        };

                        // Add the parameters to the command
                        cmd.Parameters.AddRange(pram);

                        // Execute the stored procedure
                        cmd.ExecuteNonQuery();

                        // Retrieve the calculated price after tax
                        priceAfterTax = (decimal)pram[10].Value;

                        // Display the result in the TextBlock
                        PriceAfterTaxTextBlock.Text = $"Price After Tax: {priceAfterTax:C}";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }
    }
}
