using System.ComponentModel.DataAnnotations;

public class VehicleTypeAttribute : ValidationAttribute
{
    public override bool IsValid(object value)
    {
        string strValue = value as string;

        if (!string.IsNullOrWhiteSpace(strValue))
        {
            switch (strValue.ToUpper())
            {
                case "BUS":
                case "CAR":
                case "TRUCK":
                    return true;
                default:
                    return false;
            }
        }

        return true;
    }
}