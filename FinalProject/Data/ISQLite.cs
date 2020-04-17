using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Data
{//referenced from https://www.youtube.com/watch?v=nFkwRuTG8eM&list=PLV916idiqLvcKS1JY3S3jHWx9ELGJ1cJB&index=5
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
