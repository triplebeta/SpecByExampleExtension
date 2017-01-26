using System;
using Microsoft.VisualStudio.Shell;
using System.Windows.Forms;
using System.Diagnostics;

namespace SpecByExample.PageAdapterGenerator
{
    // For some mysterious reason, the Custom Tool no longer gets registered if this file is removed.
    // Eventhough it does not make sense since it should not do anything special as the Custom Tool
    // class itself already applies a similar attribute named CodeGeneratorRegistration.

    /// <summary>
    /// Registers the assembly for the custom tool
    /// </summary>
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
    public sealed class ProvideAssemblyObjectAttribute : RegistrationAttribute
    {
        private readonly Type _objectType;
        private RegistrationMethod _registrationMethod;

        public ProvideAssemblyObjectAttribute(Type objectType)
        {
            if (objectType == null)
                throw new ArgumentNullException(nameof(objectType));
            _objectType = objectType;
        }

        public Type ObjectType
        {
            get { return _objectType; }
        }

        public RegistrationMethod RegistrationMethod
        {
            get { return _registrationMethod; }
            set { _registrationMethod = value; }
        }

        private string ClsidRegKey
        {
            get { return string.Format(@"CLSID\{0}", ObjectType.GUID.ToString("B")); }
        }

        public override void Register(RegistrationContext context)
        {
            try
            {
                using (Key key = context.CreateKey(ClsidRegKey))
                {
                    key.SetValue(string.Empty, ObjectType.FullName);
                    key.SetValue("InprocServer32", ObjectType.Assembly.FullName); // context.InprocServerPath); // @"C:\WINDOWS\SYSTEM32\MSCOREE.DLL");
                    key.SetValue("Class", ObjectType.FullName);
                    if (context.RegistrationMethod != RegistrationMethod.Default)
                        _registrationMethod = context.RegistrationMethod;

                    key.SetValue("ThreadingModel", "Both");
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public override void Unregister(RegistrationContext context)
        {
            context.RemoveKey(ClsidRegKey);
        }
    }
}
