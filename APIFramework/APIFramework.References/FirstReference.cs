using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIFramework.References
{
    public class FirstReference : DynamicObject, Reference<Database>
    {
        private IDictionary<string, object> _propertyBag;

        public FirstReference()
        {
            _propertyBag = new Dictionary<string, object>();
        }

        public string DestinationPropertyName
        {
            get
            {
                return "Data";
            }
        }

        public string ReferenceIdentifier
        {
            get
            {
                return (string)(_propertyBag.ContainsKey("ReferenceIdentifier") ? _propertyBag["ReferenceIdentifier"] : null);
            }

            set
            {
                _propertyBag["ReferenceIdentifier"] = value;
            }
        }
        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            _propertyBag[binder.Name] = value;
            return true;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            return _propertyBag.TryGetValue(binder.Name, out result);
        }

        public override IEnumerable<string> GetDynamicMemberNames()
        {
            return _propertyBag != null ? _propertyBag.Keys : Enumerable.Empty<string>();
        }
    }
}
