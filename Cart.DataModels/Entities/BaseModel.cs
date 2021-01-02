using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cart.DataModels.Entities
{
    public class BaseModel : IDisposable
    {

        [Column("RECORD_STATUS_ID")]
        public long RecordStatusId { get; set; }

        private bool disposed;
        ~BaseModel()
        {
            Dispose(false);
        }

        /// <summary>
        /// Disposes all external resources.
        /// </summary>
        /// <param name="disposing">The dispose indicator.</param>
        protected void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {

                }

                disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
