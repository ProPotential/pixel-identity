﻿using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Pixel.Identity.UI.Client.Components
{
    public partial class EditableCollection<TItem, TValue> : ComponentBase
    {
        private int itemSize = 3;
        [Parameter]
        [SuppressMessage("Usage", "BL0007:Component parameters should be auto properties", Justification = "The validation in Set would be lost.")]
        public int ItemSize
        {
            get => itemSize;
            set
            {
                if(value >0 && value <= 12)
                {
                    itemSize = value;
                }
            }
        }

        private int spacing = 2;
        [Parameter]
        [SuppressMessage("Usage", "BL0007:Component parameters should be auto properties", Justification = "The validation in Set would be lost.")]
        public int Spacing
        {
            get => spacing;
            set
            {
                if(value > 0 && value <= 16)
                {
                    spacing = value;
                }
            }
        }

        [Parameter]
        public IEnumerable<TItem> Items { get; set; }
      
        [Parameter]
        public RenderFragment<TItem> ItemTemplate { get; set; }     

        [Parameter]
        public EventCallback<TItem> OnDeleteItem { get; set; }

        [Parameter]
        public TValue NewItem { get; set; }

        [Parameter]
        public RenderFragment<TValue> AddItemTemplate { get; set; }

        [Parameter]
        public EventCallback<TValue> OnAddNewItem { get; set; }

        public bool CanAddItem => AddItemTemplate != null;

    }
}
