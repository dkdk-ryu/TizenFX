/*
 * Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the License);
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an AS IS BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Collections.Generic;

namespace ElmSharp
{
    public enum ContextPopupDirection
    {
        Down,
        Right,
        Left,
        Up,
        Unknown
    }

    public class ContextPopup : Layout
    {
        HashSet<ContextPopupItem> _children = new HashSet<ContextPopupItem>();
        SmartEvent _dismissed;
        Interop.Evas.SmartCallback _onSelected;

        public ContextPopup(EvasObject parent) : base(parent)
        {
            _dismissed = new SmartEvent(this, this.RealHandle, "dismissed");
            _dismissed.On += (sender, e) =>
            {
                Dismissed?.Invoke(this, EventArgs.Empty);
            };
            _onSelected = (data, obj, info) =>
            {
                ContextPopupItem item = ItemObject.GetItemById((int)data) as ContextPopupItem;
                item?.SendSelected();
            };
        }

        public event EventHandler Dismissed;

        public ContextPopupDirection Direction
        {
            get
            {
                return (ContextPopupDirection)Interop.Elementary.elm_ctxpopup_direction_get(RealHandle);
            }
        }

        public bool IsHorizontal
        {
            get
            {
                return Interop.Elementary.elm_ctxpopup_horizontal_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_ctxpopup_horizontal_set(RealHandle, value);
            }
        }

        public bool AutoHide
        {
            get
            {
                return !Interop.Elementary.elm_ctxpopup_auto_hide_disabled_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_ctxpopup_auto_hide_disabled_set(RealHandle, !value);
            }
        }

        public void SetDirectionPriorty(ContextPopupDirection first, ContextPopupDirection second, ContextPopupDirection third, ContextPopupDirection fourth)
        {
            Interop.Elementary.elm_ctxpopup_direction_priority_set(RealHandle, (int)first, (int)second, (int)third, (int)fourth);
        }

        public ContextPopupItem Append(string label)
        {
            return Append(label, null);
        }

        public ContextPopupItem Append(string label, EvasObject icon)
        {
            ContextPopupItem item = new ContextPopupItem(label, icon);
            item.Handle = Interop.Elementary.elm_ctxpopup_item_append(RealHandle, label, icon, _onSelected, (IntPtr)item.Id);
            AddInternal(item);
            return item;
        }

        public void Dismiss()
        {
            Interop.Elementary.elm_ctxpopup_dismiss(RealHandle);
        }

        public bool IsAvailableDirection(ContextPopupDirection direction)
        {
            return Interop.Elementary.elm_ctxpopup_direction_available_get(RealHandle, (int)direction);
        }

        public override int Opacity
        {
            get
            {
                return Color.Default.A;
            }

            set
            {
                Console.WriteLine("ContextPopup instance doesn't support to set Opacity.");
            }
        }

        protected override IntPtr CreateHandle(EvasObject parent)
        {
            return Interop.Elementary.elm_ctxpopup_add(parent.Handle);
        }

        void AddInternal(ContextPopupItem item)
        {
            _children.Add(item);
            item.Deleted += Item_Deleted;
        }

        void Item_Deleted(object sender, EventArgs e)
        {
            _children.Remove((ContextPopupItem)sender);
        }
    }
}
