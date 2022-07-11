namespace EcommAppBLL.Utility
{/// <summary>
/// This is PropertyCopy class thatis used in Views to copy the Properties.
/// </summary>
/// <typeparam name="TSource"></typeparam>
/// <typeparam name="TTarget"></typeparam>
    public class PropertyCopy<TSource, TTarget> where TSource : class
                                            where TTarget : class
    {
        public static void Copy(TSource source, TTarget target)
        {
            var sourceProperties = source.GetType().GetProperties();
            var targetProperties = target.GetType().GetProperties();

            foreach (var sourceProperty in sourceProperties)
            {
                foreach (var targetProperty in targetProperties)
                {
                    if (sourceProperty.Name == targetProperty.Name && sourceProperty.PropertyType == targetProperty.PropertyType)
                    {
                        targetProperty.SetValue(target, sourceProperty.GetValue(source));
                        break;
                    }
                }
            }
        }
    }
}
