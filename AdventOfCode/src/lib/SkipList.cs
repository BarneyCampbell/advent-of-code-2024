using System.Collections;
using System.Data;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Serialization.Metadata;
using System.Threading.Tasks.Dataflow;

namespace AdventOfCode.Lib;

public class SkipList<T>(IEnumerable<T> underlying, int skip) : IEnumerable<T>
{
    private readonly IEnumerable<T> _underlying = underlying;
    private int _skip = skip;

    public IEnumerator<T> GetEnumerator()
    {
        return new SkipListEnumerator<T>(_underlying, _skip);
    }

    private IEnumerator GetEnumerator1()
    {
        return GetEnumerator();
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator1();
    }

    public void UpdateSkipIndex(int index)
    {
        _skip = index;
    }
}

public class SkipListEnumerator<T>(IEnumerable<T> underlying, int skip) : IEnumerator<T>
{
    private readonly IEnumerable<T> _underlying = underlying;
    private int _skip = skip;

    private int _index = -1;
    private T? _current;
    public T Current
    {
        get
        {
            if (_index > _underlying.Count())
            {
                throw new InvalidOperationException();
            }
            _current ??= _underlying.ElementAt(_index);

            return _current;
        }
    }

    private object Current1
    {
        get { return Current!; }
    }
    object IEnumerator.Current
    {
        get { return Current1; }
    }

    public bool MoveNext()
    {
        _index += _index + 1 == _skip ? 2 : 1;
        
        try
        {
            _current = _underlying.ElementAt(_index);
        }
        catch 
        {
            return false;
        }
        return true;
    }

    public void Reset()
    {
        _current = _underlying.ElementAt(0);
        _index = -1;
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
    ~SkipListEnumerator()
    {
        Dispose();
    }
}