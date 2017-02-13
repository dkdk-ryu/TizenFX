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

namespace ElmSharp
{
    public class EdjeObject
    {
        IntPtr _edjeHandle;

        internal EdjeObject(IntPtr handle)
        {
            _edjeHandle = handle;
        }

        public EdjeTextPartObject this[string part]
        {
            get
            {
                if (Interop.Elementary.edje_object_part_exists(_edjeHandle, part))
                {
                    return new EdjeTextPartObject(_edjeHandle, part);
                }
                return null;
            }
        }

        public void EmitSignal(string emission, string source)
        {
            Interop.Elementary.edje_object_signal_emit(_edjeHandle, emission, source);
        }

        public void DeleteColorClass(string part)
        {
            Interop.Elementary.edje_object_color_class_del(_edjeHandle, part);
        }
    }

    public class EdjeTextPartObject
    {
        string _part;
        IntPtr _edjeHandle;

        internal EdjeTextPartObject(IntPtr edjeHandle, string part)
        {
            _edjeHandle = edjeHandle;
            _part = part;
        }

        public string Name { get { return _part; } }

        public string Text {
            get
            {
                return Interop.Elementary.edje_object_part_text_get(_edjeHandle, _part);
            }
            set
            {
                Interop.Elementary.edje_object_part_text_set(_edjeHandle, _part, value);
            }
        }

        public string TextStyle
        {
            get
            {
                return Interop.Elementary.edje_object_part_text_style_user_peek(_edjeHandle, _part);
            }
            set
            {
                if (value == null)
                {
                    Interop.Elementary.edje_object_part_text_style_user_pop(_edjeHandle, _part);
                }
                else
                {
                    Interop.Elementary.edje_object_part_text_style_user_push(_edjeHandle, _part, value);
                }
            }
        }

        public Rect Geometry
        {
            get
            {
                int x, y, w, h;
                Interop.Elementary.edje_object_part_geometry_get(_edjeHandle, _part, out x, out y, out w, out h);
                return new Rect(x, y, w, h);
            }
        }

        public Size TextBlockNativeSize
        {
            get
            {
                int w;
                int h;
                IntPtr part = Interop.Elementary.edje_object_part_object_get(_edjeHandle, _part);
                Interop.Evas.evas_object_textblock_size_native_get(part, out w, out h);
                return new Size(w, h);
            }
        }

        public Size TextBlockFormattedSize
        {
            get
            {
                int w;
                int h;
                IntPtr part = Interop.Elementary.edje_object_part_object_get(_edjeHandle, _part);
                Interop.Evas.evas_object_textblock_size_formatted_get(part, out w, out h);
                return new Size(w, h);
            }
        }
    }
}
