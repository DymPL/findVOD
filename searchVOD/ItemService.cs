using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace searchVOD
{
    public class ItemService
    {
        public List<Item> Items { get; set; }
        public ItemService()
        {
            Items = new List<Item>();
        }
        public ConsoleKeyInfo AddNewItemView(MenuActionService actionService)
        {
            var addNewItemMenu = actionService.GetMenuActionsByMenuName("AddNewItemMenu");
            Console.WriteLine("Wybierz kategorię: ");

            for (int i = 0; i < addNewItemMenu.Count; i++)
            {
                Console.WriteLine($"{addNewItemMenu[i].Id} .{addNewItemMenu[i].Name}");
            }

            var operation = Console.ReadKey();
            return operation;
        }
        public int AddNewItem(char itemType)
        {
            int itemTypeId;
            Int32.TryParse(itemType.ToString(), out itemTypeId);
            Item item = new Item();
            item.TypeId = itemTypeId;
            Console.WriteLine("Podaj numer ID dla nowego elementu: ");

            var id = Console.ReadLine();
            int itemId;
            Int32.TryParse(id, out itemId);
            Console.WriteLine("Podaj nazwę nowego elementu: ");
            var name = Console.ReadLine();

            item.Id = itemId;
            item.Name = name;

            Items.Add(item);
            return itemId;
        }

      

        public int RemoveItemView()
        {
            Console.WriteLine("Podaj numer ID do usunięcia: ");
            var itemId = Console.ReadKey();
            int id;
            Int32.TryParse(itemId.KeyChar.ToString(), out id);
            return id;
        }
        public void RemoveItem(int removeId)
        {
            Item producToRemove = new Item();              
            foreach(var item in Items)
            {
                if(item.Id == removeId)
                {
                    producToRemove = item;
                    break;
                }
            }
            Items.Remove(producToRemove);
        }

    }
}
