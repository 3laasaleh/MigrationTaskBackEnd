using Migration_Task.Data.Enums;


namespace MigrationTask.BLL.Extensions
{
    public static class productStatusEnumEx
    {
        public static bool GetBoolValue(this ProductStatusEnum status)
        {
            return status == 0 ? true : false; ;
        }
    }

}
