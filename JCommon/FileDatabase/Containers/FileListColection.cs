using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JCommon.FileDatabase.Containers
{
    public class FileListColection
    {

        /// <summary>
        /// ListID, FileItem
        /// </summary>
        Dictionary<int, FileItems> Lists = new Dictionary<int, FileItems>();

        public FileItems[] GetLists()
        {
            return Lists.Values.ToArray();
        }

        public FileRow GetValue(int listId, int itemid, int rowId)
        {
            FileItem item = GetItem(listId, itemid);
            if(item != null)
            {
               return item.GetRow(rowId);
            }
            return null;
        }

        public FileItem GetItem(int listId, int itemid)
        {
            if(Lists.TryGetValue(listId, out FileItems items))
            {
                return items.GetItem(itemid);
            }

            return null;
        }

        public FileItems GetList(int listId)
        {
            if (Lists.TryGetValue(listId, out FileItems items))
            {
                return items;
            }
            else
            {
                Lists[listId] = new FileItems() { ListId = listId, ListName = "New" };
                return Lists[listId];
            }
        }

        public bool SetItem(int listId, FileItem item)
        {
            FileItems list = GetList(listId);

            if (list != null)
            {
                list.SetItem(item);
                return true;
            }
            return false;
        }

        public int GetItemCount(int listId)
        {
            if (Lists.TryGetValue(listId, out FileItems items))
            {
                return items.Count;
            }
            return 0;
        }

        public void SetListName(int listId, string listName)
        {
            FileItems list = GetList(listId);
            if (list != null)
            {
                list.ListName = listName;
                Lists[list.ListId] = list;
            }
        }

        public void AddNew(int listId)
        {
            FileItems list = GetList(listId);
            if (list != null)
            {
                list.SetItem(new FileItem() { ItemId = list.GetNewId, ItemName = "New" });
                Lists[list.ListId] = list;
            }
        }

        public void RemoveItem(int listId, int itemId)
        {
            FileItems list = GetList(listId);
            if (list != null)
            {
                list.Remove(itemId);
            }      
        }

        public void DeleteRow(int listId, int itemId, int rowId)
        {
            FileItems list = GetList(listId);
            if (list != null)
            {
                FileItem item = list.GetItem(itemId);
                if(item != null)
                {
                    item.RemoveRow(rowId);
                }
            }
        }

        public void CloneAdd(int listId, FileItem selectedItem)
        {
            FileItems list = GetList(listId);
            if (list != null)
            {
                FileItem item = new FileItem(selectedItem)
                {
                    ItemId = list.GetNewId
                };
                list.SetItem(item);
                Lists[list.ListId] = list;
            }
        }

        public void DeleteList(int listId)
        {
            FileItems[] items = GetLists();
            Lists = new Dictionary<int, FileItems>();
            for (int i = 0; i < items.Length; i++)
            {
                int RowCount = Lists.Count();
                if (i == listId) continue;
                items[RowCount].ListId = RowCount;
                Lists[RowCount] = items[RowCount];
            }
        }
    }
}
