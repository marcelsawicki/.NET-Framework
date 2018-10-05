using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using WebApplication1;

namespace WebApplication1.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using WebApplication1;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Devices>("Devices");
    builder.EntitySet<DeviceProperties>("DeviceProperties"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class DevicesController : ODataController
    {
        private Entities db = new Entities();

        // GET: odata/Devices
        [EnableQuery]
        public IQueryable<Devices> GetDevices()
        {
            return db.Devices;
        }

        // GET: odata/Devices(5)
        [EnableQuery]
        public SingleResult<Devices> GetDevices([FromODataUri] int key)
        {
            return SingleResult.Create(db.Devices.Where(devices => devices.Id == key));
        }

        // PUT: odata/Devices(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<Devices> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Devices devices = db.Devices.Find(key);
            if (devices == null)
            {
                return NotFound();
            }

            patch.Put(devices);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DevicesExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(devices);
        }

        // POST: odata/Devices
        public IHttpActionResult Post(Devices devices)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Devices.Add(devices);
            db.SaveChanges();

            return Created(devices);
        }

        // PATCH: odata/Devices(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Devices> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Devices devices = db.Devices.Find(key);
            if (devices == null)
            {
                return NotFound();
            }

            patch.Patch(devices);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DevicesExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(devices);
        }

        // DELETE: odata/Devices(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            Devices devices = db.Devices.Find(key);
            if (devices == null)
            {
                return NotFound();
            }

            db.Devices.Remove(devices);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/Devices(5)/DeviceProperties
        [EnableQuery]
        public IQueryable<DeviceProperties> GetDeviceProperties([FromODataUri] int key)
        {
            return db.Devices.Where(m => m.Id == key).SelectMany(m => m.DeviceProperties);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DevicesExists(int key)
        {
            return db.Devices.Count(e => e.Id == key) > 0;
        }
    }
}
