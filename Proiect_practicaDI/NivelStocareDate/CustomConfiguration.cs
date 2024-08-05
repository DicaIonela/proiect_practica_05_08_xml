using System.Configuration;

namespace Proiect_practicaDI
{
    public class UtilizatoriSection : ConfigurationSection
    {
        [ConfigurationProperty("", IsDefaultCollection = true)]
        public UtilizatorCollection Utilizatori
        {
            get { return (UtilizatorCollection)this[""]; }
        }
    }

    [ConfigurationCollection(typeof(UtilizatorElement), AddItemName = "add", CollectionType = ConfigurationElementCollectionType.BasicMap)]
    public class UtilizatorCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new UtilizatorElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((UtilizatorElement)element).Nume;
        }

        public void Add(UtilizatorElement element)
        {
            BaseAdd(element);
        }

        public void Remove(UtilizatorElement element)
        {
            if (BaseIndexOf(element) >= 0)
            {
                BaseRemove(element.Nume);
            }
        }

        public new UtilizatorElement this[string name]
        {
            get { return (UtilizatorElement)BaseGet(name); }
        }
    }

    public class UtilizatorElement : ConfigurationElement
    {
        [ConfigurationProperty("key", IsRequired = true, IsKey = true)]
        public string Nume
        {
            get { return (string)this["key"]; }
            set { this["key"] = value; }
        }

        [ConfigurationProperty("value", IsRequired = true)]
        public string Valoare
        {
            get { return (string)this["value"]; }
            set { this["value"] = value; }
        }
    }
    public class TestBenchSection : ConfigurationSection
    {
        [ConfigurationProperty("", IsDefaultCollection = true)]
        public TestBenchCollection TestBenches
        {
            get { return (TestBenchCollection)this[""]; }
        }
    }

    [ConfigurationCollection(typeof(TestBenchElement), AddItemName = "add", CollectionType = ConfigurationElementCollectionType.BasicMap)]
    public class TestBenchCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new TestBenchElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((TestBenchElement)element).Nume;
        }

        public void Add(TestBenchElement element)
        {
            BaseAdd(element);
        }

        public void Remove(TestBenchElement element)
        {
            if (BaseIndexOf(element) >= 0)
            {
                BaseRemove(element.Nume);
            }
        }

        public new TestBenchElement this[string name]
        {
            get { return (TestBenchElement)BaseGet(name); }
        }
    }

    public class TestBenchElement : ConfigurationElement
    {
        [ConfigurationProperty("key", IsRequired = true, IsKey = true)]
        public string Nume
        {
            get { return (string)this["key"]; }
            set { this["key"] = value; }
        }

        [ConfigurationProperty("value", IsRequired = true)]
        public string Valoare
        {
            get { return (string)this["value"]; }
            set { this["value"] = value; }
        }
    }
}
