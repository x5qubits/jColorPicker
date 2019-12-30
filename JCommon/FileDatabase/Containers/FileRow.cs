using JCommon.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace JCommon.FileDatabase.Containers
{
    public enum FileRowType
    {
        Byte,
        Short,
        Int,
        Float,
        Double,
        String,
        Boolean,
        
    }
    public class FileItem
    {
        Dictionary<int, FileRow> rows = new Dictionary<int, FileRow>();
        public FileItem()
        {

        }
        public FileItem(FileItem selectedItem)
        {
            foreach(KeyValuePair<int, FileRow> exr in selectedItem.rows)
            {
                rows.Add(exr.Key, new FileRow(exr.Value));
            }
            ItemName = selectedItem.ItemName + "[clone]";

        }

        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public int RowCount => rows.Count;

        public FileRow GetRow(int RowId)
        {
            if (rows.TryGetValue(RowId, out FileRow row))
                return row;

            return null;
        }

        public void SetRow(FileRow row)
        {
            rows[row.RowIndex] = ConvertRow(row, row.RowType, row.RowValue.ToString());
        }

        public FileRow[] GetRows()
        {
            return rows.Values.ToArray();
        }

        public void AddRow()
        {
            rows[RowCount] = new FileRow()
            {
                RowIndex = RowCount,
                RowName = "New Row",
                RowValue = (int)0,
                RowType = FileRowType.Int
            };
        }

        private FileRow ConvertRow(FileRow Row, FileRowType type, string newValue)
        {
            switch (type)
            {
                case FileRowType.Byte:
                    Row.RowValue = newValue.ToByte();
                    break;
                case FileRowType.Int:
                    Row.RowValue = newValue.ToInt32();
                    break;
                case FileRowType.Float:
                    Row.RowValue = newValue.ToSingle();
                    break;
                case FileRowType.Double:
                    Row.RowValue = newValue.ToDouble();
                    break;
                case FileRowType.Boolean:
                    Row.RowValue = newValue.ToBoolean();
                    break;
                case FileRowType.Short:
                    Row.RowValue = newValue.ToShort();
                    break;
                case FileRowType.String:
                    Row.RowValue = newValue;
                    break;
            }
            return Row;
        }

        public void RemoveRow(int rowId)
        {
            FileRow[] items = GetRows();
            rows = new Dictionary<int, FileRow>();
            for (int i = 0; i < items.Length; i++)
            {
                if (i == rowId) continue;
                items[RowCount].RowIndex = RowCount;
                rows[RowCount] = items[RowCount];
            }
        }

        public void MoveUp(int RowIndex)
        {
            if (rows.ContainsKey(RowIndex))
            {
                FileRow x = rows[RowIndex - 1];
                x.RowIndex = RowIndex - 1;
                FileRow y = rows[RowIndex];
                y.RowIndex = RowIndex;
                rows[RowIndex - 1] = y;
                rows[RowIndex] = x;
            }
        }

        public void MoveDown(int RowIndex)
        {
            if (rows.ContainsKey(RowIndex))
            {
                FileRow x = rows[RowIndex + 1];
                x.RowIndex = RowIndex + 1;
                FileRow y = rows[RowIndex];
                y.RowIndex = RowIndex;
                rows[RowIndex + 1] = y;
                rows[RowIndex] = x;
            }
        }
    }

    public class FileRow
    {

        public FileRow() { }
        public FileRow(FileRow value)
        {
            RowIndex = value.RowIndex;
            RowName = value.RowName;
            RowType = value.RowType;
            RowValue = value.RowValue;
        }

        public int RowIndex { get; set; }
        public string RowName { get; set; }
        public FileRowType RowType { get; set; }
        public object RowValue { get; set; }
    }
}
