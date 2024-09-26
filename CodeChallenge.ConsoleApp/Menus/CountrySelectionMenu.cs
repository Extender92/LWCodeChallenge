using CodeChallange.Core.Models;

namespace CodeChallenge.ConsoleApp.Menus
{
    internal class CountrySelectionMenu
    {
        private int menuWidth;

        public CountrySelectionMenu(int menuWidth)
        {
            this.menuWidth = menuWidth;
        }

        public void DrawMenu(List<CountryDataModel> countries, int selectedIndex)
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("Select a Country:");

            for (int i = 0; i < countries.Count; i++)
            {
                if (i == selectedIndex)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                }

                string countryName = countries[i].CountryName.Length > menuWidth
                    ? countries[i].CountryName.Substring(0, menuWidth - 3) + "..."
                    : countries[i].CountryName.PadRight(menuWidth);

                Console.SetCursorPosition(0, i + 2);
                Console.Write(countryName);
                Console.ResetColor();
            }
        }
    }
}
