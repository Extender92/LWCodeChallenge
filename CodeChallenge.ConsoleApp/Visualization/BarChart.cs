using CodeChallange.Core.Models;

namespace CodeChallenge.ConsoleApp.Visualization
{
    internal class BarChart
    {
        private int chartHeight;
        private int startX;
        private int startY;
        private int width;

        public BarChart(int chartHeight, int startX, int startY)
        {
            this.chartHeight = chartHeight;
            this.startX = startX;
            this.startY = startY;
            width = Console.WindowWidth - startX;
        }

        public void DrawBarChart(CountryDataModel country)
        {
            double maxRate = Math.Max(
                country.UnemploymentStats.Max(u => u.TotalRate),
                Math.Max(
                    country.UnemploymentStats.Max(u => u.MaleRate),
                    country.UnemploymentStats.Max(u => u.FemaleRate)
                )
            );

            DrawVerticalScale(maxRate);

            Console.SetCursorPosition(startX, startY);
            Console.WriteLine($"Unemployment Data for {country.CountryName}");

            for (int i = 0; i < country.UnemploymentStats.Count; i++)
            {
                var rates = new List<double>
                {
                    country.UnemploymentStats[i].TotalRate,
                    country.UnemploymentStats[i].MaleRate,
                    country.UnemploymentStats[i].FemaleRate
                };

                List<int> scaledRates = rates.Select(rate => ScaleRateToBarHeight(rate, maxRate, chartHeight)).ToList();

                DrawBar(scaledRates, country.UnemploymentStats[i].Year, rates);
            }
        }

        private void DrawVerticalScale(double maxRate)
        {
            int divisions = 4;
            double increment = maxRate / divisions;

            for (int i = 0; i <= divisions; i++)
            {
                int yPosition = 2 + startY + (chartHeight - 1) - (i * (chartHeight - 1) / divisions);
                Console.SetCursorPosition(startX - 6, yPosition);
                Console.Write(new string(' ', 6));
                Console.SetCursorPosition(startX - 6, yPosition);
                Console.Write($"{(increment * i):N2}");
            }
        }

        private void DrawBar(List<int> rates, int year, List<double> actualRates)
        {
            int yearIndex = year - 1997;
            int spacingBetweenBars = 0;
            int spacingBetweenYears = 5;
            int groupStartX = startX + (yearIndex * spacingBetweenYears);

            for (int i = 0; i < rates.Count; i++)
            {
                int barLength = rates[i];
                int xPosition = groupStartX + (i * (spacingBetweenBars + 1));

                for (int j = 0; j < barLength; j++)
                {
                    int yPosition = startY + chartHeight - j + 1;
                    Console.SetCursorPosition(xPosition, yPosition);
                    Console.Write("#");
                }

                Console.SetCursorPosition(xPosition, startY + chartHeight + 1);
                Console.Write(GetLabelForRate(i));
                Console.ResetColor();
            }

            Console.SetCursorPosition(groupStartX, startY + chartHeight + 2);
            Console.Write(year);

            for (int i = 0; i < rates.Count; i++)
            {
                int xPosition = groupStartX;

                Console.SetCursorPosition(xPosition, startY + chartHeight + 3 + (i * 2));
                Console.Write(GetLabelForRate(i));

                Console.ResetColor();

                Console.SetCursorPosition(xPosition, startY + chartHeight + 4 + (i * 2));
                Console.Write(new string(' ', 5));
                Console.SetCursorPosition(xPosition, startY + chartHeight + 4 + (i * 2));
                Console.Write($"{actualRates[i]:N1}");
            }
        }

        private string GetLabelForRate(int rateIndex)
        {
            switch (rateIndex)
            {
                case 0: // TotalRate
                    Console.ForegroundColor = ConsoleColor.Green;
                    return "T";
                case 1: // MaleRate
                    Console.ForegroundColor = ConsoleColor.Blue;
                    return "M";
                case 2: // FemaleRate
                    Console.ForegroundColor = ConsoleColor.Red;
                    return "F";
                default:
                    Console.ResetColor();
                    return "";
            }
        }

        private int ScaleRateToBarHeight(double rate, double maxRate, int chartHeight)
        {
            double scaledRate = (rate / maxRate) * chartHeight;
            return Math.Max(0, (int)scaledRate);
        }

        public void ClearChartArea(int height)
        {
            for (int i = 0; i < chartHeight + 2; i++)
            {
                Console.SetCursorPosition(startX, startY + i);
                Console.WriteLine(new string(' ', width));
            }
        }
    }
}
