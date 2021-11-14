using System;
using System.Collections;
using Croisant_Crawler.Data;

namespace Croisant_Crawler.Drawing
{
    public class Selector
    {
        public bool IsActive { get; private set; }

        Vector2Int Corner;
        int Spacing;
        int ItemCount;
        string Shape;
        bool IsReactingToNumberInput;

        public int CursorIndex { get; private set; }

        public Selector(Vector2Int corner, int spacing, int itemCount, string shape, bool isReactingToNumberInput = false)
        {
            (Corner, Spacing, ItemCount, Shape, IsReactingToNumberInput) = (corner, spacing, itemCount, shape, isReactingToNumberInput);
            UpdateCursor(ConsoleKey.D0);
        }

        public void UpdateCursor(ConsoleKey input)
        {
            if(IsActive is false)
                return;
            
            int newIndex;
            if(IsReactingToNumberInput && int.TryParse(input.ToString(), result: out newIndex))
                newIndex -= 1;
            else
                newIndex = CursorIndex + input switch{
                    ConsoleKey.W or ConsoleKey.D => -1,
                    ConsoleKey.S or ConsoleKey.A => 1,
                    _ => 0
                };
            newIndex = (new RangeInt(ItemCount - 1)).Clamp(newIndex);

            EraseCursor();
            CursorIndex = newIndex;
            DrawCursor();
        }

        public void EraseCursor()
            => Draw.At(Corner + (0, Spacing * CursorIndex), new string(' ', Shape.Length));

        public void DrawCursor()
            => Draw.At(Corner + (0, Spacing * CursorIndex), Shape);

        public Selector SetActive(bool isActive)
        {
            IsActive = isActive;

            if(IsActive)
                DrawCursor();
            else
                EraseCursor();

            // To chain it with other methods.
            return this;
        }
    }
}