using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Populator
{
	public static class PopulatorExtensions
	{
		
		public static TTarget PopulateWith<TTarget, TSource>(this TTarget target, TSource src)
			where TTarget : class
			where TSource : class
		{
			var srcProps = src.GetType().GetProperties();
			var targetProps = target.GetType().GetProperties();
			var intersect = srcProps.Intersect(targetProps, new PropertyComparer());
			//intersect.ToList().ForEach(propertyInfo => propertyInfo.SetValue(target, propertyInfo.GetValue(src)));
			foreach (var propertyInfo in intersect)
			{
				var value = propertyInfo.GetValue(src, null);
				var prop = target.GetType().GetProperty(propertyInfo.Name);
				prop.SetValue(target, value);
			}
			return target;
		}

		private class PropertyComparer : IEqualityComparer<PropertyInfo>
		{
			public bool Equals(PropertyInfo x, PropertyInfo y)
			{
				return x.PropertyType == y.PropertyType && x.Name == y.Name;
			}

			public int GetHashCode(PropertyInfo obj)
			{
				return obj.Name.GetHashCode();
			}
		}
	}
}
