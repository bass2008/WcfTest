﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.34209
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WcfTestApp.WcfService {
    using System;
    
    
    /// <summary>
    ///   Класс ресурса со строгой типизацией для поиска локализованных строк и т.д.
    /// </summary>
    // Этот класс создан автоматически классом StronglyTypedResourceBuilder
    // с помощью такого средства, как ResGen или Visual Studio.
    // Чтобы добавить или удалить член, измените файл .ResX и снова запустите ResGen
    // с параметром /str или перестройте свой проект VS.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class StringResources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal StringResources() {
        }
        
        /// <summary>
        ///   Возвращает кэшированный экземпляр ResourceManager, использованный этим классом.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("WcfTestApp.WcfService.StringResources", typeof(StringResources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Перезаписывает свойство CurrentUICulture текущего потока для всех
        ///   обращений к ресурсу с помощью этого класса ресурса со строгой типизацией.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на yourLogin@mail.ru.
        /// </summary>
        internal static string EmailSenderLogin {
            get {
                return ResourceManager.GetString("EmailSenderLogin", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на ATTENTION.
        /// </summary>
        internal static string EmailSenderMailTheme {
            get {
                return ResourceManager.GetString("EmailSenderMailTheme", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на yourPass.
        /// </summary>
        internal static string EmailSenderPass {
            get {
                return ResourceManager.GetString("EmailSenderPass", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на smtp.mail.ru.
        /// </summary>
        internal static string EmailSenderServer {
            get {
                return ResourceManager.GetString("EmailSenderServer", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на C:\log.txt.
        /// </summary>
        internal static string FileLogerPath {
            get {
                return ResourceManager.GetString("FileLogerPath", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на C:\smsLoger.txt.
        /// </summary>
        internal static string SmsLogerPath {
            get {
                return ResourceManager.GetString("SmsLogerPath", resourceCulture);
            }
        }
    }
}
