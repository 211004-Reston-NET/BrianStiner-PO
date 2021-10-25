
using Models;
using System;
namespace UserInterface{
    public sealed class Current{    
        public static Customer customer = new Customer();            // The current customer
        public static Storefront storefront = new Storefront();      // The current storefront


        private static readonly Current instance = new Current();    // Singleton instance for Current
        static Current(){} 
        private Current(){}    
        public static Current Instance{get{return instance;}}    
    }  
}