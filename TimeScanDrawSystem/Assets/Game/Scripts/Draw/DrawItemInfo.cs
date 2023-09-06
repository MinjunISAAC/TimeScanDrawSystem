// ----- User Defined
using InGame.ForItem;

namespace InGame.ForDraw
{
    [System.Serializable]
    public class DrawItemInfo
    {
        public EItemType ItemType = EItemType.Unknown;
        public DrawItem  DrawItem = null;
    }
}