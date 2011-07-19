﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;

namespace GitUI
{
    partial class FormVerify
    {
        private sealed class SortableLostObjectsList : BindingList<LostObject>
        {
            public void AddRange(IEnumerable<LostObject> lostObjects)
            {
                LostObjects.AddRange(lostObjects);
            }

            protected override bool SupportsSortingCore
            {
                get { return true; }
            }

            protected override void ApplySortCore(PropertyDescriptor propertyDescriptor, ListSortDirection direction)
            {
                LostObjects.Sort(LostObjectsComparer.Create(propertyDescriptor, direction == ListSortDirection.Descending));
            }

            private List<LostObject> LostObjects
            {
                get { return (List<LostObject>)Items; }
            }

            private static class LostObjectsComparer
            {
                private static readonly Dictionary<string, Comparison<LostObject>> PropertyComparers = new Dictionary<string, Comparison<LostObject>>();

                static LostObjectsComparer()
                {
                    AddSortableProperty(lostObject => lostObject.Type, (x, y) => string.Compare(x.Type, y.Type, StringComparison.CurrentCulture));
                    AddSortableProperty(lostObject => lostObject.Hash, (x, y) => string.Compare(x.Hash, y.Hash, StringComparison.InvariantCulture));
                    AddSortableProperty(lostObject => lostObject.Author, (x, y) => string.Compare(x.Author, y.Author, StringComparison.CurrentCulture));
                    AddSortableProperty(lostObject => lostObject.Date, (x, y) => x.Date.HasValue && y.Date.HasValue
                        ? DateTime.Compare(x.Date.Value, y.Date.Value)
                        : Comparer<bool>.Default.Compare(x.Date.HasValue, y.Date.HasValue));
                    AddSortableProperty(lostObject => lostObject.Subject, (x, y) => string.Compare(x.Subject, y.Subject, StringComparison.CurrentCulture));
                }

                /// <summary>
                /// Creates a comparer to sort lostObjects by specified property.
                /// </summary>
                /// <param name="propertyDescriptor">Property to sort by.</param>
                /// <param name="isReversedComparing">Use reversed sorting order.</param>
                public static Comparison<LostObject> Create(PropertyDescriptor propertyDescriptor, bool isReversedComparing)
                {
                    Comparison<LostObject> comparer;
                    if (PropertyComparers.TryGetValue(propertyDescriptor.Name, out comparer))
                        return isReversedComparing ? (x, y) => comparer(y, x) : comparer;
                    throw new NotSupportedException(string.Format("Custom sort by {0} property is not supported.", propertyDescriptor.Name));
                }

                /// <summary>
                /// Adds custom property comparer.
                /// </summary>
                /// <typeparam name="T">Property type.</typeparam>
                /// <param name="expr">Property to sort by.</param>
                /// <param name="propertyComparer">Property values comparer.</param>
                private static void AddSortableProperty<T>(Expression<Func<LostObject, T>> expr, Comparison<LostObject> propertyComparer)
                {
                    PropertyComparers[((MemberExpression)expr.Body).Member.Name] = propertyComparer;
                }
            }
        }
    }
}
