namespace Lesson_2._8.MyList;

public class MyList : IMyList
{

    private int[] items;
    private int count;

    public MyList()
    {
        items = new int[4];
        count = 0;
    }

    public void AddItem(int item)
    {
        if (count == items.Length)
        {
            Resize();
        }
        items[count++] = item;
    }

    public int GetItemAt(int index)
    {
        CheckIndex(index);
        return items[index];
    }

    private void Resize()
    {
        var newItems = new int[items.Length * 2];
        for (var i = 0; i < items.Length; i++)
        {
            newItems[i] = items[i];
        }

        items = newItems;
    }

    private void CheckIndex(int index)
    {
        if (0 > index || count <= index)
        {
            throw new IndexOutOfRangeException();
        }
    }

    public void AddItemsRange(int[] nums)
    {
        for (int i = 0; i < nums.Length; i++)
        {
            AddItem(nums[i]);
        }
    }

    public int GetItemIndex(int item)
    {
        for (var i = 0; i < count; i++)
        {
            if (items[i] == item)
            {
                return i;
            }
        }
        return -1;
    }

    public void RemoveItemAt(int index)
    {
        throw new NotImplementedException();
    }

    public void ReplaceAllItems(int oldElement, int newElement)
    {
        throw new NotImplementedException();
    }
}
