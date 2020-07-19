using System;
using System.Reflection;
using UnityEngine;

namespace core.utils
{
    public abstract class InjectableMonoBehaviour : MonoBehaviour
    {
        private readonly FieldAttributeInjector injector = new FieldAttributeInjector();

        public virtual void PreStart()
        {
        }

        public virtual void PostStart()
        {
        }

        private void Start()
        {
            PreStart();
            injector.InjectByAttribute(this);
            PostStart();
        }
    }

    public class FieldAttributeInjector
    {
        public void InjectByAttribute(MonoBehaviour injectable)
        {
            Type injectableType = injectable.GetType();
            foreach (var fieldInfo in injectableType.GetFields())
            {
                try
                {
                    UnityInject attribute = fieldInfo.GetCustomAttribute(typeof(UnityInject)) as UnityInject;
                    if (attribute != null)
                    {
                        GameObject suggestedGameObject;
                        if (attribute.TagName != null)
                            suggestedGameObject = GameObject.FindGameObjectWithTag(attribute.TagName);
                        else
                            suggestedGameObject = GameObject.Find(fieldInfo.Name);
                        fieldInfo.SetValue(injectable, suggestedGameObject);
                    }
                }
                catch (Exception e)
                {
                    Debug.LogError("Could not inject to field " + injectable.GetType() + " : " + fieldInfo.Name);
                    Debug.LogError(e);
                }
            }
        }
    }

    public class UnityInject : Attribute
    {
        public string TagName { get; }

        public UnityInject(string tagName)
        {
            TagName = tagName;
        }

        public UnityInject()
        {
            TagName = null;
        }
    }
}