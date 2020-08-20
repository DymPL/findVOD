using System;
using System.ComponentModel;

namespace searchVOD
{
    class Program
    {
        //Stała 
        const string Stala = "string jakis który bedzie niezmienny";
        static void Main(string[] args)
        {
            // 1. Dodaj film
            // 2. Usunięcie filmu
            // 3. Sprawdzenie ilości filmów
            // 4. Wyszukanie filmu po kategorii 
            // 5. Usunięcie filmu
            // 6. Konto Admin
            // 7. Konto Użytkownika

            MenuActionService actionService = new MenuActionService();

            actionService = Initialize(actionService);

            Console.WriteLine("Witaj w aplikacji FindVOD \r\n");
            while (true)
            {

            
            Console.WriteLine("Co chcesz zrobić? \r\n");

            var mainMenu = actionService.GetMenuActionsByMenuName("Main");
            for (int i = 0; i < mainMenu.Count; i++)
            {
                Console.WriteLine($"{mainMenu[i].Id}. {mainMenu[i].Name}");
            }

            var operation = Console.ReadKey();
            ItemService itemService = new ItemService();
            switch (operation.KeyChar)
            {
                case '1': 
                    var keyInfo = itemService.AddNewItemView(actionService);
                    var id = itemService.AddNewItem(keyInfo.KeyChar);
                    break;
                case '2':
                    var removeId = itemService.RemoveItemView();
                    itemService.RemoveItem(removeId);
                    break;
                case '3':
                    break;
                case '4':
                    break;
                default:
                    Console.WriteLine("Nieprawidłowy wybór");
                    break;
            }
            }
        }

        private static MenuActionService Initialize(MenuActionService actionService)
        {
            actionService.AddNewAction(1,"Dodaj film", "Main");
            actionService.AddNewAction(2,"Usuń film", "Main");
            actionService.AddNewAction(3,"Pokaż szczegóły", "Main");
            actionService.AddNewAction(4,"Lista filmów", "Main");
            

            actionService.AddNewAction(1, "Komedia", "AddNewItemMenu");
            actionService.AddNewAction(2, "Kryminał", "AddNewItemMenu");
            actionService.AddNewAction(3, "Horror", "AddNewItemMenu");

            return actionService;
        }
    }
}
