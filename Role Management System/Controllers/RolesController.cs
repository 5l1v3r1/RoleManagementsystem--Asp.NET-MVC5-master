using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Role_Management_System.DataServices;

namespace Role_Management_System.Controllers
{
    [Authorize(Roles ="Admin")]
    public class RolesController : Controller
    {
        private AuthenticateEntities1 db = new AuthenticateEntities1();

        // GET: Roles
        public async Task<ActionResult> Index()
        {
            return View(await db.webpages_Roles.ToListAsync());
        }

        // GET: Roles/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            webpages_Roles webpages_Roles = await db.webpages_Roles.FindAsync(id);
            if (webpages_Roles == null)
            {
                return HttpNotFound();
            }
            return View(webpages_Roles);
        }

        // GET: Roles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Roles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "RoleId,RoleName")] webpages_Roles webpages_Roles)
        {
            if (ModelState.IsValid)
            {
                db.webpages_Roles.Add(webpages_Roles);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(webpages_Roles);
        }

        // GET: Roles/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            webpages_Roles webpages_Roles = await db.webpages_Roles.FindAsync(id);
            if (webpages_Roles == null)
            {
                return RedirectToAction("Index");
                //return HttpNotFound();
            }
            return View(webpages_Roles);
        }

        // POST: Roles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "RoleId,RoleName")] webpages_Roles webpages_Roles)
        {
            if (ModelState.IsValid)
            {
                db.Entry(webpages_Roles).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(webpages_Roles);
        }

        // GET: Roles/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            webpages_Roles webpages_Roles = await db.webpages_Roles.FindAsync(id);
            if (webpages_Roles == null)
            {
                return HttpNotFound();
            }
            return View(webpages_Roles);
        }

        // POST: Roles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int? id)
        {
            if (id==null)
            {
                return RedirectToAction("Index");
            }
            webpages_Roles webpages_Roles = await db.webpages_Roles.FindAsync(id);
            db.webpages_Roles.Remove(webpages_Roles);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
