//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HobbyGames
{
    using System;
    using System.Collections.Generic;
    
    public partial class Storage
    {
        public int IDStorage { get; set; }
        public int Store { get; set; }
        public int Game { get; set; }
        public int Kolvo { get; set; }
    
        public virtual Contacts Contacts { get; set; }
        public virtual TableGames TableGames { get; set; }
    }
}
