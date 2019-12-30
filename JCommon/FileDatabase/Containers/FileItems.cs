using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JCommon.FileDatabase.Containers
{
    public class FileItems
    {
        public string ListName { get; set; }
        public int ListId { get; set; }
        public int GetNewId => Items.Count;
        public int Count => Items.Count;

        Dictionary<int, FileItem> Items = new Dictionary<int, FileItem>();

        public FileItem GetItem(int itemId)
        {
            if (Items.TryGetValue(itemId, out FileItem data))
                return data;

            return null;
        }

        public FileRow GetRow(int itemId, int RowId)
        {
            FileItem item = GetItem(itemId);
            if(item != null)
            {
                return item.GetRow(RowId);
            }
            return null;
        }

        public void SetItem(FileItem item)
        {
            Items[item.ItemId] = item;
        }

        public bool SetRow(int itemId, FileRow row)
        {
            FileItem item = GetItem(itemId);
            if (item != null)
            {
                item.SetRow(row);
            }

            return false;
        }

        public FileItem[] GetItems()
        {
            return Items.Values.ToArray();
        }

        public void Remove(int itemId)
        {
            FileItem[] items = GetItems();
            Items = new Dictionary<int, FileItem>();
            for(int i = 0; i < items.Length; i++)
            {
                if (i == itemId) continue;
                items[GetNewId].ItemId = GetNewId;
                Items[GetNewId] = items[GetNewId];
            }
        }
    }
}
