using com.karabaev.reactivetypes.Property;
using NUnit.Framework;

namespace com.karabaev.reactivetypes.editor.tests.ReactiveProperty
{
  [TestFixture]
  public class ReactivePropertyTests
  {
    [Test]
    public void FiresChangedEventWhenChangeNullToReference()
    {
      var property = new ReactiveProperty<TestClassWithEquals?>(null);
      var isChanged = false;
      property.Changed += (_, _) => isChanged = true;

      property.Value = new TestClassWithEquals { Float = 2.0f, Object = new object() };
      
      Assert.True(isChanged);
    }

    [Test]
    public void FiresChangedEventWhenChangeReferenceToNull()
    {
      var property = new ReactiveProperty<TestClassWithEquals?>(new TestClassWithEquals { Float = 1.0f, Object = new object() });
      var isChanged = false;
      property.Changed += (_, _) => isChanged = true;

      property.Value = null;
      
      Assert.True(isChanged);
    }

    [Test]
    public void DoesNotFireChangedEventWhenChangeNullToNull()
    {
      var property = new ReactiveProperty<TestClassWithEquals?>(null);
      var isChanged = false;
      property.Changed += (_, _) => isChanged = true;

      property.Value = null;
      
      Assert.False(isChanged);
    }

    
    [Test]
    public void FiresChangedEventWithReferenceTypeWithEquals()
    {
      var property = new ReactiveProperty<TestClassWithEquals>(new TestClassWithEquals { Float = 1.0f, Object = new object() });
      var isChanged = false;
      property.Changed += (_, _) => isChanged = true;

      property.Value = new TestClassWithEquals { Float = 2.0f, Object = new object() };
      
      Assert.True(isChanged);
    }
    
    [Test]
    public void DoesNotFireChangedEventWithReferenceTypeWithEqualsWhenFieldsAreEqual()
    {
      var objectField = new object();
      var property = new ReactiveProperty<TestClassWithEquals>(new TestClassWithEquals { Float = 1.0f, Object = objectField });
      var isChanged = false;
      property.Changed += (_, _) => isChanged = true;

      property.Value = new TestClassWithEquals { Float = 1.0f, Object = objectField };
      
      Assert.False(isChanged);
    }
    
    [Test]
    public void FiresChangedEventWithReferenceTypeWithoutEquals()
    {
      var property = new ReactiveProperty<TestClassWithoutEquals>(new TestClassWithoutEquals { Float = 1.0f, Object = new object() });
      var isChanged = false;
      property.Changed += (_, _) => isChanged = true;

      property.Value = new TestClassWithoutEquals { Float = 1.0f, Object = new object() };
      
      Assert.True(isChanged);
    }
    
    [Test]
    public void DoesNotFireChangedEventWithReferenceTypeWithoutEqualsWhenSameInstance()
    {
      var instance = new TestClassWithoutEquals { Float = 1.0f, Object = new object() };
      var property = new ReactiveProperty<TestClassWithoutEquals>(instance);
      var isChanged = false;
      property.Changed += (_, _) => isChanged = true;

      property.Value = instance;
      
      Assert.False(isChanged);
    }
    
    [Test]
    public void FiresChangedEventWithReferenceTypeWithoutEqualsWhenFieldsEqual()
    {
      var objectField = new object(); 
      var property = new ReactiveProperty<TestClassWithoutEquals>(new TestClassWithoutEquals { Float = 1.0f, Object = objectField });
      var isChanged = false;
      property.Changed += (_, _) => isChanged = true;

      property.Value = new TestClassWithoutEquals { Float = 1.0f, Object = objectField };
      
      Assert.True(isChanged);
    }

    [Test]
    public void FiresChangedEventWithValueTypeWithEquals()
    {
      var property = new ReactiveProperty<TestStructWithEquals>(new TestStructWithEquals { Float = 1.0f, Object = new object() });
      var isChanged = false;
      property.Changed += (_, _) => isChanged = true;

      property.Value = new TestStructWithEquals { Float = 2.0f, Object = new object() };
      
      Assert.True(isChanged);
    }
    
    [Test]
    public void DoesNotFireChangedEventWithValueTypeWithEqualsWhenFieldsAreEqual()
    {
      var objectField = new object();
      var property = new ReactiveProperty<TestStructWithEquals>(new TestStructWithEquals { Float = 1.0f, Object = objectField });
      var isChanged = false;
      property.Changed += (_, _) => isChanged = true;

      property.Value = new TestStructWithEquals { Float = 1.0f, Object = objectField };
      
      Assert.False(isChanged);
    }
    
    [Test]
    public void FiresChangedEventWithValueTypeWithoutEquals()
    {
      var property = new ReactiveProperty<TestStructWithoutEquals>(new TestStructWithoutEquals { Float = 1.0f, Object = new object() });
      var isChanged = false;
      property.Changed += (_, _) => isChanged = true;

      property.Value = new TestStructWithoutEquals { Float = 2.0f, Object = new object() };
      
      Assert.True(isChanged);
    }
    
    [Test]
    public void DoesNotFireChangedEventWithValueTypeWithoutEqualsWhenFieldsAreEqual()
    {
      var objectField = new object();
      var property = new ReactiveProperty<TestStructWithoutEquals>(new TestStructWithoutEquals { Float = 1.0f, Object = objectField });
      var isChanged = false;
      property.Changed += (_, _) => isChanged = true;

      property.Value = new TestStructWithoutEquals { Float = 1.0f, Object = objectField };
      
      Assert.False(isChanged);
    }
  }
}