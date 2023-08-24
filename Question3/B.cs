class B
{
    public const A a;  
    public B()  { a.a = 10; } // A is set as a constant above, so it cannot be set in B's constructor
}