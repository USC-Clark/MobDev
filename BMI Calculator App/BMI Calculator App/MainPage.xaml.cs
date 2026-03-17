namespace BMI_Calculator_App
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCalculateClicked(object? sender, EventArgs e)
        {
            try
            {
                double height = Convert.ToDouble(HeightEntry.Text);
                double weight = Convert.ToDouble(WeightEntry.Text);

                double bmi = weight / (height * height);

                string category = "";

                if (bmi < 18.5)
                    category = "Underweight";
                else if (bmi < 24.9)
                    category = "Normal weight";
                else if (bmi < 29.9)
                    category = "Overweight";
                else
                    category = "Obese";

                ResultLabel.Text = $"BMI: {bmi:F2}\nCategory: {category}";
            }
            catch
            {
                ResultLabel.Text = "Please enter valid numeric values.";
            }
        }
    }
}