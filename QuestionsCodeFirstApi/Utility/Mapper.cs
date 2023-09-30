﻿namespace QuestionsCodeFirstApi.Utility
{
    /// <summary>
    /// Mapper
    /// </summary>
    public class Mapper
    {
        /// <summary>
        /// Method to map between object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objfrom">Origin</param>
        /// <param name="objto">Destiny</param>
        /// <returns></returns>
        public static T Map<T>(object objfrom, T objto)
        {
            var ToProperties = objto.GetType().GetProperties();
            var FromProperties = objfrom.GetType().GetProperties();

            ToProperties.ToList().ForEach(o =>
            {
                var fromp = FromProperties.FirstOrDefault(x => x.Name == o.Name && x.PropertyType == o.PropertyType);
                if (fromp != null)
                {
                    o.SetValue(objto, fromp.GetValue(objfrom));
                }
            });

            return objto;
        }
    }
}
