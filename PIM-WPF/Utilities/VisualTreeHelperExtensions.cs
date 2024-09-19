using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;

namespace PIM_WPF.Utilities
{
    public static class VisualTreeHelperExtensions
    {       
            public static T FindVisualChild<T>(this DependencyObject obj) where T : DependencyObject
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(obj, i);
                    if (child != null && child is T)
                    {
                        return (T)child;
                    }
                    else
                    {
                        T childOfChild = FindVisualChild<T>(child);
                        if (childOfChild != null)
                        {
                            return childOfChild;
                        }
                    }
                }
                return null;
            }
        }
    }

