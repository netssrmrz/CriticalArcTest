using System;
using System.Configuration;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting;

namespace CriticalArcTest.IO.Input
{
  public abstract class Field
  {
    protected bool haveInput;

    public string Question { get; set; }
    public string FieldName { get; set; }
    public bool HaveInput { get => haveInput; }

    public static bool InputObj(string keyPrefix, object obj, IDevice io, Utils.Log log)
    {
      Field[] fields = Field.AllFromConfig(keyPrefix, log);
      bool res = false;

      if (fields != null)
      {
        foreach (Field inputField in fields)
        {
          if (inputField!=null)
          {
            inputField.WriteQuestion(io, log);
            inputField.ReadInput(obj, io, log);
          }
        }
        res = true;
      }

      return res;
    }

    public static Field[] AllFromConfig(string prefix, Utils.Log log)
    {
      Field[] fields = null;
      int i;
      string fieldCount = ConfigurationManager.AppSettings.Get(prefix + ".Count");
      if (fieldCount!=null)
      {
        int count = int.Parse(fieldCount);

        fields = new Field[count];
        for (i = 0; i < count; i++)
        {
          fields[i] = Field.FromConfig(prefix + i, log);
        }
      }
      else
      {
        Utils.Log.Write(log, "Field.AllFromConfig(): Could not find config for " + prefix);
      }

      return fields;
    }

    public static Field FromConfig(string configKey, Utils.Log log)
    {
      Field field = null;

      string typeName = ConfigurationManager.AppSettings.Get(configKey + ".Type");
      string question = ConfigurationManager.AppSettings.Get(configKey + ".Question");
      string fieldName = ConfigurationManager.AppSettings.Get(configKey + ".FieldName");

      if (!string.IsNullOrEmpty(typeName) && !string.IsNullOrEmpty(question) && !string.IsNullOrEmpty(fieldName))
      {
        try
        {
          ObjectHandle obj = Activator.CreateInstance(null, typeName);
          field = (Field)obj.Unwrap();
          field.Question = question;
          field.FieldName = fieldName;
        }
        catch (TypeLoadException)
        {
          Utils.Log.Write(log, "Field.FromConfig(): Could not get class for field " + typeName);
        }
      }
      else
      {
        Utils.Log.Write(log, "Field.FromConfig(): Could not find config for field " + configKey);
      }

      return field;
    }

    public void WriteQuestion(IDevice io, Utils.Log log)
    {
      io.WriteLine(Question + " " + this.GetDefaultDescription());
      Utils.Log.Write(log, "InputField.WriteQuestion(): Question is \"" + this.Question + "\"");
    }

    public void ReadInput(object obj, IDevice io, Utils.Log log)
    {
      object inputVal = null;

      this.haveInput = false;
      while (!this.haveInput)
      {
        inputVal = this.Parse(io);
      }

      System.Reflection.PropertyInfo property = obj.GetType().GetProperty(this.FieldName);
      if (property != null)
      {
        property.SetValue(obj, inputVal);
      }
      else
      {
        Utils.Log.Write(log, "InputField.ReadInput(): could not find property \"" + this.FieldName + "\"");
      }

      Utils.Log.Write(log, "InputField.ReadInput(): inputVal is \"" + inputVal + "\"");
    }

    public abstract object Parse(IDevice io);

    public abstract string GetDefaultDescription();
  }
}
