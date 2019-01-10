using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yookey.WisdomClassed.SIP.Admin.Models;
using Yookey.WisdomClassed.SIP.Business.Com;
using Yookey.WisdomClassed.SIP.Business.LawManger;
using Yookey.WisdomClassed.SIP.Model.Com;
using Yookey.WisdomClassed.SIP.Model.LawManger;

namespace Yookey.WisdomClassed.SIP.Admin.Controllers
{
    public class LawMangerController : BaseController
    {
        //
        // GET: /LawManger/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LawDetial(string id)
        {
            LawMangerEntity model = new LawMangerBll().Single(id);
            return View(model);
        }

        /// <summary>
        /// 添加法律法规页面
        /// add by lpl
        /// </summary>
        /// <returns></returns>
        public ActionResult LawAdd(string ParentId)
        {
            LawMangerEntity lawMangerEntity = new LawMangerBll().Single(ParentId);



            ViewBag.ParentName = lawMangerEntity.Name; ;




            return View();
        }

        /// <summary>
        /// 添加和编辑分类
        /// add by lpl
        /// 2019-1-9
        /// </summary>
        /// <returns></returns>
        public ActionResult LawEdit(string ParentId)
        {
            
            LawMangerEntity lawMangerEntity = new LawMangerBll().Single(ParentId);

            //编辑情况：1，新增情况：0
            if (Request["isEdit"] == "1")
            {
                ViewBag.ParentName = new LawMangerBll().Single(lawMangerEntity.ParentId).Name;
                ViewBag.Name = lawMangerEntity.Name;
            }
            else
            {
                ViewBag.ParentName = lawMangerEntity.Name;

            }



            return View();
        }

        /// <summary>
        /// 加载法律法规树
        /// add by lpl
        /// 2019-1-8
        /// </summary>
        /// <returns></returns>
        public ActionResult LoadLawTree()
        {

            List<MiniTree> list = InitTree();
            return Json(list, "text/html", JsonRequestBehavior.AllowGet);

        }


        /// <summary>
        /// 新增分类
        /// add by lpl
        /// 2019-1-8
        /// </summary>
        /// <param name="typename"></param>
        /// <returns></returns>
        public string LawTypeAdd(string typename)
        {
            try
            {
                string parentId = Request["ParentId"].ToString();

                LawMangerEntity entity = new LawMangerEntity()
                {
                    Id = Guid.NewGuid().ToString(),
                    ParentId = parentId,
                    Name = typename,
                    Rowsatus = 1,
                };

                if (new LawMangerBll().PersistNewItem(entity))
                {
                    return "1";
                }

                return "0";


            }
            catch (Exception e)
            {
                return "0";
            }
        }

        /// <summary>
        /// 编辑分类
        /// </summary>
        /// <param name="typename"></param>
        /// <returns></returns>
        public string LawTypeEdit(string typename)
        {
            try
            {
                string Id = Request["Id"].ToString();

      

                LawMangerEntity entity = new LawMangerBll().Single(Id);

                entity.Name = typename;
               

                if (new LawMangerBll().PersistUpdatedItem(entity))
                {
                    return "1";
                }

                return "0";


            }
            catch (Exception e)
            {
                return "0";
            }
        }

        /// <summary>
        /// 删除分类
        /// add by lpl
        /// 2019-1-9
        /// </summary>
        /// <returns></returns>
        public string LawTypeDel()
        {
            try
            {
                string Id = Request["Id"].ToString();



                LawMangerEntity entity = new LawMangerBll().Single(Id);

                entity.Rowsatus = 0;

                //先判断是否存在字节点，存在则不让直接删除


                if (new LawMangerBll().PersistUpdatedItem(entity))
                {
                    return "1";
                }

                return "0";


            }
            catch (Exception e)
            {
                return "0";
            }
        }

        [ValidateInput(false)]
        public string LawContetAdd(string content, string typename)
        {
            try
            {
                string parentId = Request["ParentId"];

                LawMangerEntity entity = new LawMangerEntity()
                {
                    Id = Guid.NewGuid().ToString(),
                    ParentId = parentId,
                    Name = typename,
                    ContentText = content,
                    Rowsatus = 1,
                };

                if (new LawMangerBll().PersistNewItem(entity))
                {
                    return "1";
                }

                return "0";


            }
            catch (Exception e)
            {
                return "0";
            }
            }




        /// <summary>
        /// 初始化树目录
        /// add by lpl
        /// 2019-1-8
        /// </summary>
        /// <returns></returns>
        public List<MiniTree> InitTree()
        {

            var listLawManger =  new LawMangerBll().QueryList(new LawMangerEntity()
            {
                Id = "0059"
            });

            List<MiniTree> listTree = new List<MiniTree>();
            foreach (var list in listLawManger)
            {
                MiniTree rooTree = new MiniTree();
                rooTree.id = list.Id;
                rooTree.text = list.Name;
                rooTree.ParentId = list.ParentId;
                rooTree.children = CreateChild(rooTree.id);
                listTree.Add(rooTree);
            }

            return listTree;
        }

        /// <summary>
        /// 递归生成加载子节点
        /// add by lpl
        /// 2019-1-8
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public List<MiniTree> CreateChild(string Id)
        {

            var listLawManger = new LawMangerBll().QueryList(new LawMangerEntity()
            {
                ParentId = Id
            });

            List<MiniTree> listTree = new List<MiniTree>();
            foreach (var list in listLawManger)
            {
                MiniTree rooTree = new MiniTree();
                rooTree.id = list.Id;
                rooTree.ParentId = list.ParentId;
                rooTree.text = list.Name;
                rooTree.children = CreateChild(rooTree.id);
                listTree.Add(rooTree);
            }
            return listTree;
        }

    }
}
