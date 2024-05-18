using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Soniclogistics_updated.Models;
using Soniclogistics_updated.Controllers;

namespace Soniclogistics_updated.Controllers
{
    public class GrnsController : Controller
    {
        private readonly MyDataDbContext _context;

        public GrnsController(MyDataDbContext context)
        {
            _context = context;
        }

        // GET: Grns
        public async Task<IActionResult> Index()
        {
            var myDataDbContext = _context.Grns.Include(g => g.Order);
           
            var query = from pos in _context.Pos
                        join rfq in _context.Rfqs on pos.RfqId equals rfq.RfqId
                        join product in _context.Products on rfq.ProductName equals product.ProdId
                        select new { pos, rfq, product };

            Dictionary<int, string> rfqProductsMap = new Dictionary<int, string>();

            foreach (var result in query)
            {
                if (!rfqProductsMap.ContainsKey(result.rfq.RfqId))
                {
                    rfqProductsMap[result.rfq.RfqId] = $"{result.product.ProductName} - {result.rfq.Quantity}";
                }
                else
                {
                    rfqProductsMap[result.rfq.RfqId] += $"\n{result.product.ProductName} - {result.rfq.Quantity}";
                }
            }

            ViewData["myDataDbContext"] = myDataDbContext;
            ViewData["rfqProductsMap"] = rfqProductsMap;

            return View(myDataDbContext);
            

        }

        // GET: Grns/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grn = await _context.Grns
                .Include(g => g.Order)
                .FirstOrDefaultAsync(m => m.GrnId == id);
            if (grn == null)
            {
                return NotFound();
            }

            return View(grn);
        }

        // GET: Grns/Create
        public IActionResult Create()
        {
            ViewData["OrderId"] = new SelectList(_context.Pos, "OrderId", "OrderId");
            return View();
        }

        // POST: Grns/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        // POST: Grns/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GrnId,GrnDate,Warehouse,BatchNo,ApprovedWarehouse,UnapprovedWarehouse,SupId,RfqId,OrderId")] Grn grn)
        {
            if (ModelState.IsValid)
            {
                _context.Add(grn);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // Display validation errors in the view
            var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
            ViewData["Errors"] = errors;

            ViewData["OrderId"] = new SelectList(_context.Pos, "OrderId", "OrderId", grn.OrderId);
            return View(grn);
        }

        // POST: Grns/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GrnId,GrnDate,Warehouse,BatchNo,ApprovedWarehouse,UnapprovedWarehouse,OrderId,RfqId,SupId")] Grn grn)
        {
            if (id != grn.GrnId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(grn);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GrnExists(grn.GrnId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["OrderId"] = new SelectList(_context.Pos, "OrderId", "OrderId", grn.OrderId);
            return View(grn);
        }

        // GET: Grns/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grn = await _context.Grns
                .Include(g => g.Order)
                .FirstOrDefaultAsync(m => m.GrnId == id);
            if (grn == null)
            {
                return NotFound();
            }

            return View(grn);
        }

        // POST: Grns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var grn = await _context.Grns.FindAsync(id);
            if (grn != null)
            {
                _context.Grns.Remove(grn);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GrnExists(int id)
        {
            return _context.Grns.Any(e => e.GrnId == id);
        }
    }
}