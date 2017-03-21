using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Helpers
{
    public class JsonHelper
    {
        public static string SerializeObj(object obj)
        {
            var jSetting = new JsonSerializerSettings();
            jSetting.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

         //   jSetting.ContractResolver = new SpecialContractResolver();

            return JsonConvert.SerializeObject(obj, jSetting);
        }

        public static T DeserializeObj<T>(string str)
        {
            JsonSerializerSettings jSetting = new JsonSerializerSettings();
            jSetting.NullValueHandling = NullValueHandling.Ignore;
            return JsonConvert.DeserializeObject<T>(str, jSetting);
        }


    }

    public class NullableValueProvider : IValueProvider
    {
        private readonly object _defaultValue;
        private readonly IValueProvider _underlyingValueProvider;


        public NullableValueProvider(MemberInfo memberInfo, Type underlyingType)
        {
            _underlyingValueProvider = new DynamicValueProvider(memberInfo);
            _defaultValue = Activator.CreateInstance(underlyingType);
        }

        public void SetValue(object target, object value)
        {
            _underlyingValueProvider.SetValue(target, value);
        }

        public object GetValue(object target)
        {
            return _underlyingValueProvider.GetValue(target) ?? _defaultValue;
        }
    }

    public class SpecialContractResolver : DefaultContractResolver
    {
        protected override IValueProvider CreateMemberValueProvider(MemberInfo member)
        {
            
            if (member.MemberType == MemberTypes.Property)
            {
               
                var pi = (PropertyInfo)member;
                if (pi.PropertyType.IsGenericType && pi.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                {
                    return new NullableValueProvider(member, pi.PropertyType.GetGenericArguments().First());
                }
              
            }
            else if (member.MemberType == MemberTypes.Field)
            {
                var fi = (FieldInfo)member;
                if (fi.FieldType.IsGenericType && fi.FieldType.GetGenericTypeDefinition() == typeof(Nullable<>))
                    return new NullableValueProvider(member, fi.FieldType.GetGenericArguments().First());
            }

            return base.CreateMemberValueProvider(member);
        }
    }
}
