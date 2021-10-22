
using Models;
using System;
namespace UserInterface
{
    public sealed class Current    
    {    
        public static Customer customer = new Customer();
        public static Storefront storefront = new Storefront();

        private static readonly Current instance = new Current();    
        static Current(){}
        private Current(){}    
        public static Current Instance{    
            get{return instance;}    
        }    
    }  
}