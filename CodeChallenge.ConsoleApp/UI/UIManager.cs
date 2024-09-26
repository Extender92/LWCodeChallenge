using CodeChallange.Core.Models;
using CodeChallenge.ConsoleApp.Menus;
using CodeChallenge.ConsoleApp.Visualization;

namespace CodeChallenge.ConsoleApp.UI
{
    internal class UIManager
    {
        private CountrySelectionMenu _menu;
        private BarChart _barChart;
        private int menuWidth = 28;
        private int chartHeight = 28;
        private int chartStartX = 35;
        private int chartStartY = 0;

        public UIManager()
        {
            PromptForWindowSize();
            _menu = new CountrySelectionMenu(menuWidth);
            _barChart = new BarChart(chartHeight, chartStartX, chartStartY);
        }

        public void DrawMenu(List<CountryDataModel> countries, int selectedIndex)
        {
            _menu.DrawMenu(countries, selectedIndex);
        }

        public void DrawBarChart(CountryDataModel country)
        {

            _barChart.ClearChartArea(country.UnemploymentStats.Count);
            _barChart.DrawBarChart(country);
        }

        public void PromptForWindowSize()
        {
            while (Console.WindowWidth < (menuWidth + chartStartX + 102) || Console.WindowHeight < (chartHeight + chartStartY + 10))
            {
                Console.Clear();
                Console.WriteLine("The window is too small. Please resize the window and press any key to continue.");
                Console.WriteLine($"X + {Console.WindowWidth - (menuWidth + chartStartX + 102)}");
                Console.WriteLine($"Y + {Console.WindowHeight - (chartHeight + chartStartY + 10)}");
                Console.ReadKey();
            }
            Console.Clear();
        }
    }
}
