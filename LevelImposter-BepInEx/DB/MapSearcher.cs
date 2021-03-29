﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace LevelImposter.DB
{
    static class MapSearcher
    {
        public static T SearchComponent<T>(GameObject parent, string name)
        {
            GameObject obj = SearchChildren(parent, name);
            if (obj != null)
                return obj.GetComponent<T>();
            return default(T);
        }

        public static GameObject SearchChildren(GameObject parent, string name)
        {
            List<Transform> output = new List<Transform>();
            SearchChildren(parent.transform, name, output);

            if (output.Count() <= 0)
                return null;
            return output[0].gameObject;
        }

        private static void SearchChildren(Transform parent, string name, List<Transform> output)
        {
            for (int i = 0; i < parent.childCount; i++)
            {
                Transform child = parent.GetChild(i);
                if (child.name == name)
                {
                    output.Add(child);
                }
                SearchChildren(child, name, output);
            }
        }

        public static T SearchList<T>(UnhollowerBaseLib.Il2CppReferenceArray<T> list, string name) where T : MonoBehaviour
        {
            IEnumerable<T> elem = list.Where(t => t.name == name);
            if (elem.Count() > 0)
                return elem.First();
            return null;
        }
    }
}
