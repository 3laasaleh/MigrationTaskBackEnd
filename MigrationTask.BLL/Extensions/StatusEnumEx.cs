using Migration_Task.Data.Enums;


namespace MigrationTask.BLL.Extensions
{
    public static class ProductStatusEnumEx
    {
    
        public static string GetName(this ProductStatusEnum name)
        {
            return Enum.GetName(typeof(ProductStatusEnum), name) ?? string.Empty;
        }

        public static ProductStatusEnum GetProductStatusEnum(this bool status)
        {
            return status ? ProductStatusEnum.Active : ProductStatusEnum.Inactive; ;
        }
 
    }

}
