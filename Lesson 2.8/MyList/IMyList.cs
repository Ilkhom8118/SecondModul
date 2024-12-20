namespace Lesson_2._8.MyList;

public interface IMyList
{
    void RemoveItemAt(int index);
    void AddItemsRange(int[] nums);
    void ReplaceAllItems(int oldElement, int newElement);
    int GetItemIndex(int item);
}