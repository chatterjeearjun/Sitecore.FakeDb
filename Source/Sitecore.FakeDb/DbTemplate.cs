﻿namespace Sitecore.FakeDb
{
  using System.Collections;
  using Sitecore.Data;

  public class DbTemplate : IEnumerable
  {
    public string Name { get; private set; }

    public ID ID { get; set; }

    // TODO: Hide setter
    public DbFieldCollection Fields { get; set; }

    internal DbFieldCollection StandardValues { get; private set; }

    public DbTemplate()
      : this(null)
    {
    }

    public DbTemplate(string name)
    {
      this.Name = name;
      this.Fields = new DbFieldCollection();
      this.StandardValues = new DbFieldCollection();
    }

    public DbTemplate(string name, ID id)
      : this(name)
    {
      this.ID = id;
    }

    public void Add(string fieldName)
    {
      this.Fields.Add(fieldName);
    }

    public void Add(string fieldName, string standardValue)
    {
      var id = ID.NewID;

      var field = new DbField(fieldName) { ID = id };
      this.Fields.Add(field);

      var standardValueField = new DbField(fieldName) { ID = id, Value = standardValue };
      this.StandardValues.Add(standardValueField);
    }

    public IEnumerator GetEnumerator()
    {
      return this.Fields.GetEnumerator();
    }
  }
}