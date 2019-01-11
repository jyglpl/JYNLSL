using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yookey.WisdomClassed.SIP.Admin.Models;
using Yookey.WisdomClassed.SIP.Business.Exam;
using Yookey.WisdomClassed.SIP.Common.PetaPoco;
using Yookey.WisdomClassed.SIP.Enumerate;
using Yookey.WisdomClassed.SIP.Model.Exam;


namespace Yookey.WisdomClassed.SIP.Admin.Controllers.Exam
{
    public class ExamController : BaseController
    {
        private readonly ExamInfoBll _examInfoBll = new ExamInfoBll();//考试
        private readonly ExamTypeBll _examTypeBll = new ExamTypeBll();//题库类型
        private readonly ExamThemeBll _examThemeBll = new ExamThemeBll();//试题
        private readonly ExamQuestionsBll _examQuestionsBll = new ExamQuestionsBll();//存储选中的题库
        private readonly ExamInfoMationBll _examInfoMationBll = new ExamInfoMationBll();//考试成绩
        private readonly OldAnswerBll _oldAnswerBll = new OldAnswerBll();//已考题目及答案

        private readonly QuetionTypeBll _quetionTypeBll = new QuetionTypeBll();//试题题库类型
        private readonly QuetionTitleBll _quetionTitleBll = new QuetionTitleBll(); //试题类型
        /// <summary>
        /// 模拟考试
        /// </summary>
        /// <returns></returns>
        public ActionResult SimulationExamIndex(string keywords)
        {
            var data = _examInfoBll.GetExamInfoList(new ExamInfoEntity() { PaperType = "模拟考试", keywords = keywords });
            ViewBag.Keywords = keywords;
            ViewBag.ExamData = data;
            return View();
        }

        /// <summary>
        /// 获取模拟考试信息
        /// </summary>
        /// <param name="keywords"></param>
        /// <param name="rows"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public string GetSimulationExamData(string keywords, int rows = 30, int page = 1)
        {
            var data = _examInfoBll.GetExamInfo("模拟考试", keywords, rows, page);
            var result = CommonMethod.PageToJson(CommonMethod.PageToJqGridPage(data));
            return result;
        }


        /// <summary>
        /// 试卷详情
        /// </summary>
        /// <returns></returns>
        public ActionResult SimulationExamDetail(string Id)
        {
            string Str = "";
            var entity = new ExamInfoEntity();
            if (!string.IsNullOrEmpty(Id))
            {
                var examInfo = _examInfoBll.GetExamInfoList(new ExamInfoEntity() { Tid = Id });
                if (examInfo.Any())
                {
                    entity = examInfo[0];
                }
                //选中的题库
                var typeInfo = _examQuestionsBll.GetResultSearch(new ExamQuestionsEntity() { Tid = Id });
                if (typeInfo.Any())
                {
                    foreach (var item in typeInfo)
                    {
                        Str += item.Sid + ",";
                    }
                }
            }
            //选中的题库类型
            ViewBag.ChkType = Str;
            //题库类型
            var source = _examTypeBll.GetExamList(new ExamTypeEntity());
            ViewData["Sources"] = source;
            return View(entity);
        }

        /// <summary>
        /// 根据选中的题库获取相应的数量
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public JsonResult GetItemCount(string Id)
        {
            var isOk = false;
            int Single = 0, Multiple = 0, Judge = 0;
            List<string> lst = new List<string>();//用于统计题目数量集合
            string ExamTitle = "";
            try
            {
                if (!string.IsNullOrEmpty(Id))
                {
                    string[] id = Id.Split(',');
                    int num = 0;
                    foreach (var item in id)
                    {
                        if (!string.IsNullOrEmpty(item))
                        {
                            var dataList = _examThemeBll.GetExamThemeList(new ExamThemeEntity() { SubJectId = item });
                            Single += dataList.Where<ExamThemeEntity>(x => x.QuestionsType == "00290001").ToList().Count();
                            Multiple += dataList.Where<ExamThemeEntity>(x => x.QuestionsType == "00290002").ToList().Count();
                            Judge += dataList.Where<ExamThemeEntity>(x => x.QuestionsType == "00290003").ToList().Count();
                            num++;
                        }
                    }
                    if (num == 1)
                    {
                        var examTypeList = _examTypeBll.GetExamList(new ExamTypeEntity() { SubJectId = id[0].ToString() });
                        ExamTitle = examTypeList[0].SubJectName + "试卷";
                    }
                    else
                    {
                        ExamTitle = "综合试卷";
                    }

                }
                ViewBag.Single = Single;
                ViewBag.Multiple = Multiple;
                ViewBag.Judge = Judge;
                lst.Add(Single.ToString());
                lst.Add(Multiple.ToString());
                lst.Add(Judge.ToString());
                lst.Add(ExamTitle);
                isOk = true;
            }
            catch (Exception)
            {
                isOk = false;
            }
            var result = new StatusModel<string>
            {
                rtState = isOk ? 1 : -1,
                rtData = lst,
                rtObj = null,
                rtMsrg = "成功"
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 提交试卷
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public JsonResult SubmitExamData(string Ids, ExamInfoEntity entity, FormCollection collection)
        {
            var isOk = false;
            try
            {
                //保存试卷
                if (string.IsNullOrEmpty(entity.Tid)) //新增
                {
                    entity.Tid = Guid.NewGuid().ToString();
                    entity.PaperType = "模拟考试";
                    entity.Fraction = !string.IsNullOrEmpty(entity.Fraction) ? double.Parse(entity.Fraction).ToString() : "0";
                    entity.SingleQuantity = !string.IsNullOrEmpty(entity.SingleQuantity) ? int.Parse(entity.SingleQuantity).ToString() : "0";
                    entity.ScoreScore = !string.IsNullOrEmpty(entity.ScoreScore) ? double.Parse(entity.ScoreScore).ToString() : "0";
                    entity.MultipleQuantity = !string.IsNullOrEmpty(entity.MultipleQuantity) ? int.Parse(entity.MultipleQuantity).ToString() : "0";
                    entity.MultipleScore = !string.IsNullOrEmpty(entity.MultipleScore) ? double.Parse(entity.MultipleScore).ToString() : "0";
                    entity.JudgeQuantity = !string.IsNullOrEmpty(entity.JudgeQuantity) ? int.Parse(entity.JudgeQuantity).ToString() : "0";
                    entity.JudgeScore = !string.IsNullOrEmpty(entity.JudgeScore) ? double.Parse(entity.JudgeScore).ToString() : "0";
                    entity.ZHQuantity = !string.IsNullOrEmpty(entity.ZHQuantity) ? int.Parse(entity.ZHQuantity).ToString() : "0";//综合条数
                    entity.ZHScore = !string.IsNullOrEmpty(entity.ZHScore) ? double.Parse(entity.ZHScore).ToString() : "0";//综合分值
                    entity.Time = !string.IsNullOrEmpty(entity.Time) ? Int32.Parse(entity.Time).ToString() : "0";
                    entity.PassRatio = !string.IsNullOrEmpty(entity.PassRatio) ? Int32.Parse(entity.PassRatio).ToString() : "0";
                    entity.ZJType = "随机组卷";
                    entity.NYCD = "0";//难易程度
                    entity.SHName = "0";//审核人ID
                    entity.Frequency = "10";//重考次数
                    entity.isDeleted = "0";
                    entity.Pass = "0";//允许立即得分
                    entity.ZHSc = "0";
                    entity.CreateDate = DateTime.Now;
                    _examInfoBll.InsertExam(entity);
                }
                else //更新
                {
                    _examInfoBll.UpdateExam(entity);
                }
                //保存题库,先删除原来的题库再保存
                if (!string.IsNullOrEmpty(entity.Tid))
                {
                    var typeInfo = _examQuestionsBll.GetResultSearch(new ExamQuestionsEntity() { Tid = entity.Tid });
                    if (typeInfo.Any())
                    {
                        var flag = _examQuestionsBll.DeleteEexamQuestions(entity.Tid);
                    }
                    if (!string.IsNullOrEmpty(Ids))
                    {
                        string[] id = Ids.Split(',');
                        foreach (var item in id)
                        {
                            if (!string.IsNullOrEmpty(item))
                            {
                                var flag = _examQuestionsBll.InsertEexamQuestions(entity.Tid, item);
                            }
                        }
                    }

                }
                isOk = true;
            }
            catch (Exception)
            {
                isOk = false;
            }
            var result = new StatusModel<object>
            {
                rtState = isOk ? 1 : -1,
                rtData = null,
                rtObj = null,
                rtMsrg = "成功"
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 考试界面
        /// </summary>
        /// <returns></returns>
        public ActionResult SimulationStartExam(string Id)
        {
            List<ExamInfoEntity> ExamInfoList = _examInfoBll.GetExamInfoList(new ExamInfoEntity { Tid = Id });
            List<ExamInfoList> NewExam = new List<ExamInfoList>();

            double TestCount = 0;
            double TestCT = 0;

            if (ExamInfoList.Count > 0)
            {
                SearExamTypeList(ref NewExam, ExamInfoList[0], ref TestCount, ref TestCT);

                ViewData["TypeList"] = NewExam;
                ViewData["UserName"] = CurrentUser.CrmUser.UserName;
                ViewData["DeptName"] = CurrentUser.CrmUser.DeptName;
                ViewData["TestPerio"] = ExamInfoList[0].Time;
                ViewData["TestCount"] = TestCount;
                ViewData["TestCT"] = TestCT;
                ViewData["Title"] = ExamInfoList[0].Title;
                ViewData["Know"] = ExamInfoList[0].Know;
                ViewData["Tid"] = Id;
            }



            return View();
        }

        /// <summary>
        /// 考试详情界面
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public ActionResult SimulationStartExamDetail(string Id)
        {
            List<ExamInfoMationEntity> EntityList = _examInfoMationBll.GetSearchResult(new ExamInfoMationEntity { Id = Id });
            List<ExamInfoList> NewExam = new List<ExamInfoList>();


            double TestCount = 0;
            double TestCT = 0;

            if (EntityList.Count > 0)
            {
                List<ExamInfoEntity> ExamInfoList = _examInfoBll.GetExamInfoList(new ExamInfoEntity { Tid = EntityList[0].Tid });



                ShowExamTypeList(ref NewExam, ExamInfoList[0], ref TestCount, ref TestCT, EntityList[0]);

                ViewData["TypeList"] = NewExam;
                ViewData["UserName"] = CurrentUser.CrmUser.UserName;
                ViewData["DeptName"] = CurrentUser.CrmUser.DeptName;
                ViewData["TestPerio"] = ExamInfoList[0].Time;
                ViewData["TestCount"] = TestCount;
                ViewData["TestCT"] = TestCT;
                ViewData["Title"] = ExamInfoList[0].Title;
                ViewData["Know"] = ExamInfoList[0].Know;
                ViewData["Tid"] = Id;
                ViewData["Time"] = EntityList[0].Time;
            }

            return View();
        }

        /// <summary>
        /// 查询所有该试卷的题型
        /// </summary>
        /// <param name="NewExam"></param>
        /// <param name="Exam"></param>
        public void SearExamTypeList(ref List<ExamInfoList> NewExam, ExamInfoEntity Exam, ref double TestCount, ref double TestCT)
        {
            //单选题
            if (!string.IsNullOrEmpty(Exam.SingleQuantity) && Exam.SingleQuantity != "0")
            {
                ExamInfoList newSing = new ExamInfoList()
                {
                    Tid = Exam.Tid,
                    OrderBy = "1",
                    PaperType = Exam.PaperType,
                    RsCode = "00290001",
                    TpType = "单选题",
                    Ord = "1",
                    Count = Exam.SingleQuantity,
                    Source = Exam.ScoreScore,
                    ExamThemList = _examThemeBll.GetExamThemeList(new ExamThemeEntity() { QuestionsType = "00290001" }).OrderBy(_ => Guid.NewGuid()).ToList()
                };
                NewExam.Add(newSing);
                TestCount += double.Parse(newSing.Count);
                TestCT += double.Parse(newSing.Count) * double.Parse(newSing.Source);
            }

            //判断题
            if (!string.IsNullOrEmpty(Exam.JudgeQuantity) && Exam.JudgeQuantity != "0")
            {
                ExamInfoList newSing = new ExamInfoList()
                {
                    Tid = Exam.Tid,
                    OrderBy = "2",
                    PaperType = Exam.PaperType,
                    RsCode = "00290003",
                    TpType = "判断题",
                    Ord = "2",
                    Count = Exam.JudgeQuantity,
                    Source = Exam.JudgeScore,
                    ExamThemList = _examThemeBll.GetExamThemeList(new ExamThemeEntity() { QuestionsType = "00290003" }).OrderBy(_ => Guid.NewGuid()).ToList()
                };
                NewExam.Add(newSing);
                TestCount += double.Parse(newSing.Count);
                TestCT += double.Parse(newSing.Count) * double.Parse(newSing.Source);
            }

            //多选题
            if (!string.IsNullOrEmpty(Exam.MultipleQuantity) && Exam.MultipleQuantity != "0")
            {
                ExamInfoList newSing = new ExamInfoList()
                {
                    Tid = Exam.Tid,
                    OrderBy = "3",
                    PaperType = Exam.PaperType,
                    RsCode = "00290002",
                    TpType = "多选题",
                    Ord = "3",
                    Count = Exam.MultipleQuantity,
                    Source = Exam.MultipleScore,
                    ExamThemList = _examThemeBll.GetExamThemeList(new ExamThemeEntity() { QuestionsType = "00290002" }).OrderBy(_ => Guid.NewGuid()).ToList()
                };
                NewExam.Add(newSing);
                TestCount += double.Parse(newSing.Count);
                TestCT += double.Parse(newSing.Count) * double.Parse(newSing.Source);
            }

            //分析题
            if (!string.IsNullOrEmpty(Exam.FXQuantity) && Exam.FXQuantity != "0")
            {
                ExamInfoList newSing = new ExamInfoList()
                {
                    Tid = Exam.Tid,
                    OrderBy = "4",
                    PaperType = Exam.PaperType,
                    RsCode = "00290004",
                    TpType = "分析题",
                    Ord = "4",
                    Count = Exam.FXQuantity,
                    Source = Exam.FXScore,
                    ExamThemList = _examThemeBll.GetExamThemeList(new ExamThemeEntity() { QuestionsType = "00290004" }).OrderBy(_ => Guid.NewGuid()).ToList()
                };
                NewExam.Add(newSing);
                TestCount += double.Parse(newSing.Count);
                TestCT += double.Parse(newSing.Count) * double.Parse(newSing.Source);
            }

            //作文题
            if (!string.IsNullOrEmpty(Exam.ZWQuantity) && Exam.ZWQuantity != "0")
            {
                ExamInfoList newSing = new ExamInfoList()
                {
                    Tid = Exam.Tid,
                    OrderBy = "5",
                    PaperType = Exam.PaperType,
                    RsCode = "00290005",
                    TpType = "作文题",
                    Ord = "5",
                    Count = Exam.ZWQuantity,
                    Source = Exam.ZWScore,
                    ExamThemList = _examThemeBll.GetExamThemeList(new ExamThemeEntity() { QuestionsType = "00290005" }).OrderBy(_ => Guid.NewGuid()).ToList()
                };
                NewExam.Add(newSing);
                TestCount += double.Parse(newSing.Count);
                TestCT += double.Parse(newSing.Count) * double.Parse(newSing.Source);
            }

            //论述题
            if (!string.IsNullOrEmpty(Exam.LSQuantity) && Exam.LSQuantity != "0")
            {
                ExamInfoList newSing = new ExamInfoList()
                {
                    Tid = Exam.Tid,
                    OrderBy = "6",
                    PaperType = Exam.PaperType,
                    RsCode = "00290006",
                    TpType = "论述题",
                    Ord = "6",
                    Count = Exam.LSQuantity,
                    Source = Exam.LSScore,
                    ExamThemList = _examThemeBll.GetExamThemeList(new ExamThemeEntity() { QuestionsType = "00290006" }).OrderBy(_ => Guid.NewGuid()).ToList()
                };
                NewExam.Add(newSing);
                TestCount += double.Parse(newSing.Count);
                TestCT += double.Parse(newSing.Count) * double.Parse(newSing.Source);
            }

            //填空题
            if (!string.IsNullOrEmpty(Exam.TKQuantity) && Exam.TKQuantity != "0")
            {
                ExamInfoList newSing = new ExamInfoList()
                {
                    Tid = Exam.Tid,
                    OrderBy = "7",
                    PaperType = Exam.PaperType,
                    RsCode = "00290007",
                    TpType = "填空题",
                    Ord = "7",
                    Count = Exam.TKQuantity,
                    Source = Exam.TKScore,
                    ExamThemList = _examThemeBll.GetExamThemeList(new ExamThemeEntity() { QuestionsType = "00290007" }).OrderBy(_ => Guid.NewGuid()).ToList()
                };
                NewExam.Add(newSing);
                TestCount += double.Parse(newSing.Count);
                TestCT += double.Parse(newSing.Count) * double.Parse(newSing.Source);
            }

            //简答题
            if (!string.IsNullOrEmpty(Exam.JDQuantity) && Exam.JDQuantity != "0")
            {
                ExamInfoList newSing = new ExamInfoList()
                {
                    Tid = Exam.Tid,
                    OrderBy = "8",
                    PaperType = Exam.PaperType,
                    RsCode = "00290008",
                    TpType = "简答题",
                    Ord = "8",
                    Count = Exam.JDQuantity,
                    Source = Exam.JDScore,
                    ExamThemList = _examThemeBll.GetExamThemeList(new ExamThemeEntity() { QuestionsType = "00290008" }).OrderBy(_ => Guid.NewGuid()).ToList()
                };
                NewExam.Add(newSing);
                TestCount += double.Parse(newSing.Count);
                TestCT += double.Parse(newSing.Count) * double.Parse(newSing.Source);
            }

            //综合题
            if (!string.IsNullOrEmpty(Exam.ZHQuantity) && Exam.ZHQuantity != "0")
            {
                ExamInfoList newSing = new ExamInfoList()
                {
                    Tid = Exam.Tid,
                    OrderBy = "9",
                    PaperType = Exam.PaperType,
                    RsCode = "00290009",
                    TpType = "简答题",
                    Ord = "9",
                    Count = Exam.ZHQuantity,
                    Source = Exam.ZHSc,
                    ExamThemList = _examThemeBll.GetExamThemeList(new ExamThemeEntity() { QuestionsType = "00290009" }).OrderBy(_ => Guid.NewGuid()).ToList()
                };
                NewExam.Add(newSing);
                TestCount += double.Parse(newSing.Count);
                TestCT += double.Parse(newSing.Count) * double.Parse(newSing.Source);
            }
        }

        /// <summary>
        /// 查询所有该试卷的题型
        /// </summary>
        /// <param name="NewExam"></param>
        /// <param name="Exam"></param>
        public void ShowExamTypeList(ref List<ExamInfoList> NewExam, ExamInfoEntity Exam, ref double TestCount, ref double TestCT, ExamInfoMationEntity Entity)
        {
            //单选题
            if (!string.IsNullOrEmpty(Exam.SingleQuantity) && Exam.SingleQuantity != "0")
            {
                ExamInfoList newSing = new ExamInfoList()
                {
                    Tid = Exam.Tid,
                    OrderBy = "1",
                    PaperType = Exam.PaperType,
                    RsCode = "00290001",
                    TpType = "单选题",
                    Ord = "1",
                    Count = Exam.SingleQuantity,
                    Source = Exam.ScoreScore,
                    ExamThemList = _examThemeBll.GetExamThemeList(new ExamThemeEntity() { QuestionsType = "00290001" }, Entity.OId).OrderBy(_ => Guid.NewGuid()).ToList()
                };
                NewExam.Add(newSing);
                TestCount += double.Parse(newSing.Count);
                TestCT += double.Parse(newSing.Count) * double.Parse(newSing.Source);
            }

            //判断题
            if (!string.IsNullOrEmpty(Exam.JudgeQuantity) && Exam.JudgeQuantity != "0")
            {
                ExamInfoList newSing = new ExamInfoList()
                {
                    Tid = Exam.Tid,
                    OrderBy = "2",
                    PaperType = Exam.PaperType,
                    RsCode = "00290003",
                    TpType = "判断题",
                    Ord = "2",
                    Count = Exam.JudgeQuantity,
                    Source = Exam.JudgeScore,
                    ExamThemList = _examThemeBll.GetExamThemeList(new ExamThemeEntity() { QuestionsType = "00290003" }, Entity.OId).OrderBy(_ => Guid.NewGuid()).ToList()
                };
                NewExam.Add(newSing);
                TestCount += double.Parse(newSing.Count);
                TestCT += double.Parse(newSing.Count) * double.Parse(newSing.Source);
            }

            //多选题
            if (!string.IsNullOrEmpty(Exam.MultipleQuantity) && Exam.MultipleQuantity != "0")
            {
                ExamInfoList newSing = new ExamInfoList()
                {
                    Tid = Exam.Tid,
                    OrderBy = "3",
                    PaperType = Exam.PaperType,
                    RsCode = "00290002",
                    TpType = "多选题",
                    Ord = "3",
                    Count = Exam.MultipleQuantity,
                    Source = Exam.MultipleScore,
                    ExamThemList = _examThemeBll.GetExamThemeList(new ExamThemeEntity() { QuestionsType = "00290002" }, Entity.OId).OrderBy(_ => Guid.NewGuid()).ToList()
                };
                NewExam.Add(newSing);
                TestCount += double.Parse(newSing.Count);
                TestCT += double.Parse(newSing.Count) * double.Parse(newSing.Source);
            }

            //分析题
            if (!string.IsNullOrEmpty(Exam.FXQuantity) && Exam.FXQuantity != "0")
            {
                ExamInfoList newSing = new ExamInfoList()
                {
                    Tid = Exam.Tid,
                    OrderBy = "4",
                    PaperType = Exam.PaperType,
                    RsCode = "00290004",
                    TpType = "分析题",
                    Ord = "4",
                    Count = Exam.FXQuantity,
                    Source = Exam.FXScore,
                    ExamThemList = _examThemeBll.GetExamThemeList(new ExamThemeEntity() { QuestionsType = "00290004" }, Entity.OId).OrderBy(_ => Guid.NewGuid()).ToList()
                };
                NewExam.Add(newSing);
                TestCount += double.Parse(newSing.Count);
                TestCT += double.Parse(newSing.Count) * double.Parse(newSing.Source);
            }

            //作文题
            if (!string.IsNullOrEmpty(Exam.ZWQuantity) && Exam.ZWQuantity != "0")
            {
                ExamInfoList newSing = new ExamInfoList()
                {
                    Tid = Exam.Tid,
                    OrderBy = "5",
                    PaperType = Exam.PaperType,
                    RsCode = "00290005",
                    TpType = "作文题",
                    Ord = "5",
                    Count = Exam.ZWQuantity,
                    Source = Exam.ZWScore,
                    ExamThemList = _examThemeBll.GetExamThemeList(new ExamThemeEntity() { QuestionsType = "00290005" }, Entity.OId).OrderBy(_ => Guid.NewGuid()).ToList()
                };
                NewExam.Add(newSing);
                TestCount += double.Parse(newSing.Count);
                TestCT += double.Parse(newSing.Count) * double.Parse(newSing.Source);
            }

            //论述题
            if (!string.IsNullOrEmpty(Exam.LSQuantity) && Exam.LSQuantity != "0")
            {
                ExamInfoList newSing = new ExamInfoList()
                {
                    Tid = Exam.Tid,
                    OrderBy = "6",
                    PaperType = Exam.PaperType,
                    RsCode = "00290006",
                    TpType = "论述题",
                    Ord = "6",
                    Count = Exam.LSQuantity,
                    Source = Exam.LSScore,
                    ExamThemList = _examThemeBll.GetExamThemeList(new ExamThemeEntity() { QuestionsType = "00290006" }, Entity.OId).OrderBy(_ => Guid.NewGuid()).ToList()
                };
                NewExam.Add(newSing);
                TestCount += double.Parse(newSing.Count);
                TestCT += double.Parse(newSing.Count) * double.Parse(newSing.Source);
            }

            //填空题
            if (!string.IsNullOrEmpty(Exam.TKQuantity) && Exam.TKQuantity != "0")
            {
                ExamInfoList newSing = new ExamInfoList()
                {
                    Tid = Exam.Tid,
                    OrderBy = "7",
                    PaperType = Exam.PaperType,
                    RsCode = "00290007",
                    TpType = "填空题",
                    Ord = "7",
                    Count = Exam.TKQuantity,
                    Source = Exam.TKScore,
                    ExamThemList = _examThemeBll.GetExamThemeList(new ExamThemeEntity() { QuestionsType = "00290007" }, Entity.OId).OrderBy(_ => Guid.NewGuid()).ToList()
                };
                NewExam.Add(newSing);
                TestCount += double.Parse(newSing.Count);
                TestCT += double.Parse(newSing.Count) * double.Parse(newSing.Source);
            }

            //简答题
            if (!string.IsNullOrEmpty(Exam.JDQuantity) && Exam.JDQuantity != "0")
            {
                ExamInfoList newSing = new ExamInfoList()
                {
                    Tid = Exam.Tid,
                    OrderBy = "8",
                    PaperType = Exam.PaperType,
                    RsCode = "00290008",
                    TpType = "简答题",
                    Ord = "8",
                    Count = Exam.JDQuantity,
                    Source = Exam.JDScore,
                    ExamThemList = _examThemeBll.GetExamThemeList(new ExamThemeEntity() { QuestionsType = "00290008" }, Entity.OId).OrderBy(_ => Guid.NewGuid()).ToList()
                };
                NewExam.Add(newSing);
                TestCount += double.Parse(newSing.Count);
                TestCT += double.Parse(newSing.Count) * double.Parse(newSing.Source);
            }

            //综合题
            if (!string.IsNullOrEmpty(Exam.ZHQuantity) && Exam.ZHQuantity != "0")
            {
                ExamInfoList newSing = new ExamInfoList()
                {
                    Tid = Exam.Tid,
                    OrderBy = "9",
                    PaperType = Exam.PaperType,
                    RsCode = "00290009",
                    TpType = "简答题",
                    Ord = "9",
                    Count = Exam.ZHQuantity,
                    Source = Exam.ZHSc,
                    ExamThemList = _examThemeBll.GetExamThemeList(new ExamThemeEntity() { QuestionsType = "00290009" }, Entity.OId).OrderBy(_ => Guid.NewGuid()).ToList()
                };
                NewExam.Add(newSing);
                TestCount += double.Parse(newSing.Count);
                TestCT += double.Parse(newSing.Count) * double.Parse(newSing.Source);
            }
        }


        /// <summary>
        /// 删除试卷
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public string DeleteExam(string id)
        {
            string rtMsrg;
            int rtState;
            try
            {
                var flag = _examInfoBll.DeleteExam(id);
                rtMsrg = flag ? "删除成功" : "删除失败";
                rtState = flag ? (int)OperationState.Success : (int)OperationState.Failure;
            }
            catch (Exception ex)
            {
                rtState = (int)OperationState.Error;
                rtMsrg = ex.Message;
            }
            var rtEntity = new StatusModel<DBNull>
            {
                rtData = null,
                rtMsrg = rtMsrg,
                rtState = rtState
            };
            return CommonMethod.ToJson(rtEntity);
        }

        //历史成绩
        public ActionResult ExamInfomations(string Id)
        {
            if (!string.IsNullOrEmpty(Id))
            {
                ViewBag.Id = Id;
            }
            return View();
        }

        /// <summary>
        /// 获取考试成绩
        /// </summary>
        /// <param name="keywords"></param>
        /// <param name="rows"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public string GetInfomationData(string keywords, string Tid, int rows = 30, int page = 1)
        {
            string userId = "1";
            var data = _examInfoMationBll.GetExamInfomation(keywords, Tid, userId, rows, page);
            if (data.Items.Count > 0)
            {
                foreach (var item in data.Items)
                {
                    if (!string.IsNullOrEmpty(item.Tid))
                    {
                        var lst = _examInfoBll.GetExamInfoList(new ExamInfoEntity() { Tid = item.Tid });
                        if (lst.Any())
                        {
                            item.ExamTitle = lst[0].Title;
                            item.ExamScore = lst[0].Fraction;
                        }
                    }
                }
            }
            if (!string.IsNullOrEmpty(keywords))
            {
                for (int i = 0; i < data.Items.Count; i++)
                {
                    if (!data.Items[i].ExamTitle.Contains(keywords))
                    {
                        data.Items.Remove(data.Items[i]);
                        i--;
                    }
                }
            }
            var result = CommonMethod.PageToJson(CommonMethod.PageToJqGridPage(data));
            return result;
        }

        /// <summary>
        /// 提交试卷
        /// </summary>
        /// <param name="tmlst"></param>
        /// <param name="answer"></param>
        /// <param name="tid"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult SubmitForm(string tmlst, string answer, string tid)
        {
            var isOk = false;
            try
            {
                List<ExamThemeEntity> ThemeList = _examThemeBll.GetExamThemeList(new ExamThemeEntity());

                //题目
                string[] tmlists = tmlst.Split(',');
                //答案
                string[] answerlst = answer.Split(',');

                string Oid = Guid.NewGuid().ToString();

                //考试实体
                ExamInfoEntity ExamInfo = _examInfoBll.GetExamInfoList(new ExamInfoEntity() { Tid = tid }).ToList()[0];

                double Score = 0;

                for (int i = 0; i < tmlists.Length - 1; i++)
                {
                    int IsError = 0;

                    ExamThemeEntity entity = ThemeList.Where(p => p.TItemId == tmlists[i]).ToList()[0];

                    string Answer = entity.Answer;
                    string UserAnswer = answerlst[i];
                    if (!UserAnswer.Contains("|"))
                    {
                        if (Answer != UserAnswer)
                        {
                            IsError = 1;
                        }
                    }
                    else
                    {
                        string UserAnswers = "";
                        string[] UserAnswerslst = UserAnswer.Split('|');
                        for (int y = 0; y < UserAnswerslst.Length; y++)
                        {
                            UserAnswers += UserAnswerslst;
                        }
                        if (Answer != UserAnswers)
                        {
                            IsError = 1;
                        }
                    }

                    double scores = 0;

                    switch (entity.QuestionsType)
                    {
                        //单选
                        case "00290001":
                            scores = double.Parse(ExamInfo.ScoreScore);
                            if (IsError == 0)
                            {
                                Score += scores;
                            }
                            break;
                        //复选
                        case "00290002":
                            scores = double.Parse(ExamInfo.MultipleScore);
                            if (IsError == 0)
                            {
                                Score += scores;
                            }
                            break;
                        //判断
                        case "00290003":
                            scores = double.Parse(ExamInfo.JudgeScore);
                            if (IsError == 0)
                            {
                                Score += scores;
                            }
                            break;
                        default:
                            break;
                    }

                    OldAnswerEntity OldEntity = new OldAnswerEntity()
                    {
                        OId = Oid,
                        TitemId = tmlists[i],
                        Answer = UserAnswer,
                        isError = IsError,
                        NumItem = ""
                    };

                    _oldAnswerBll.InsertOld(OldEntity);

                }
                _examInfoMationBll.InsertExamInfomation(new ExamInfoMationEntity()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Tid = tid,
                        Uid = CurrentUser.CrmUser.Id,
                        OId = Oid,
                        Time = DateTime.Now,
                        ExamScore = Score.ToString(),
                        IsPiYue = "无需批阅",
                        IsShenPi = "0"

                    });

                isOk = true;
            }
            catch (Exception)
            {
                isOk = false;
            }

            var result = new StatusModel<object>
            {
                rtState = isOk ? 1 : -1,
                rtData = null,
                rtObj = null,
                rtMsrg = "成功"
            };
            return Json(result, JsonRequestBehavior.AllowGet);

            //string Htmls = Html;
        }

        /// <summary>
        /// 正式考试
        /// </summary>
        /// <returns></returns>
        public ActionResult FormalExamIndex(string keywords)
        {
            var user = CurrentUser.CrmUser;
            string userId = user.Id;
            var data = _examInfoBll.GetExamInfoList(new ExamInfoEntity() { PaperType = "正式考试", keywords = keywords });
            foreach (var item in data)
            {
                var dataList = _examInfoMationBll.GetSearchResult(new ExamInfoMationEntity() { Tid = item.Tid, Uid = userId });
                bool flag = false;
                if (item.StartDate.ToShortDateString() != "1900/1/1" && item.EndDate.ToShortDateString() != "1900/1/1")
                {
                    if (Convert.ToDateTime(item.StartDate) <= DateTime.Now && Convert.ToDateTime(item.EndDate.ToString("yyyy-MM-dd 23:59:59")) >= DateTime.Now)
                    {
                        if (item.Frequency != "0")
                        {

                            if (dataList.Any())
                            {
                                if (Int32.Parse(item.Frequency) > dataList.Count)
                                {
                                    flag = true;
                                }
                            }
                            else if (dataList.Count == 0)
                            {
                                flag = true;
                            }

                        }
                    }
                }
                item.IsEnter = flag;
                item.SurplusCount = Int32.Parse(item.Frequency) - dataList.Count > 0 ? Int32.Parse(item.Frequency) - dataList.Count : 0;
            }
            ViewBag.Keywords = keywords;
            ViewBag.ExamData = data;
            return View();
        }

        /// <summary>
        /// 获取正式考试信息
        /// </summary>
        /// <param name="keywords"></param>
        /// <param name="rows"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public string GetFormalExamData(string keywords, int rows = 30, int page = 1)
        {
            var data = _examInfoBll.GetExamInfo("正式考试", keywords, rows, page);
            foreach (var item in data.Items)
            {
                if (!string.IsNullOrEmpty(item.Frequency) && item.Frequency != "0")
                {
                    item.Fraction = item.Fraction + "次";
                }
                else
                {
                    item.Fraction = "无限制";
                }
            }
            var result = CommonMethod.PageToJson(CommonMethod.PageToJqGridPage(data));
            return result;
        }



        /// <summary>
        /// 试卷管理
        /// </summary>
        /// <returns></returns>
        public ActionResult ExamManagement()
        {
            return View();
        }

        /// <summary>
        /// 试卷详情
        /// </summary>
        /// <returns></returns>
        public ActionResult FormalExamDetail(string Id)
        {
            bool flag = false;
            string Str = "";
            var entity = new ExamInfoEntity();
            if (!string.IsNullOrEmpty(Id))
            {
                var examInfo = _examInfoBll.GetExamInfoList(new ExamInfoEntity() { Tid = Id });
                if (examInfo.Any())
                {
                    entity = examInfo[0];
                }
                //选中的题库
                var typeInfo = _examQuestionsBll.GetResultSearch(new ExamQuestionsEntity() { Tid = Id });
                if (typeInfo.Any())
                {
                    foreach (var item in typeInfo)
                    {
                        Str += item.Sid + ",";
                    }
                }
                flag = true;
            }
            ViewBag.Flag = flag;
            //选中的题库类型
            ViewBag.ChkType = Str;
            //题库类型
            var source = _examTypeBll.GetExamList(new ExamTypeEntity());
            ViewData["Sources"] = source;
            //是否阅卷
            var readList = EnumOperate.ConvertEnumToListItems(typeof(ExamReadType), "0");
            ViewData["ExamReadType"] = readList;
            //允许立即得分绑定值
            var scoreList = EnumOperate.ConvertEnumToListItems(typeof(ExamScoreType), "0");
            ViewData["ExamScoreType"] = scoreList;
            return View(entity);
        }

        /// <summary>
        /// 提交试卷
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public JsonResult FormalExamData(string Ids, ExamInfoEntity entity, FormCollection collection)
        {
            var isOk = false;
            var username = CurrentUser.CrmUser;
            try
            {
                //保存试卷
                if (string.IsNullOrEmpty(entity.Tid)) //新增
                {
                    entity.Tid = Guid.NewGuid().ToString();
                    entity.PaperType = "正式考试";
                    entity.Publisher = username.UserName;
                    entity.Fraction = !string.IsNullOrEmpty(entity.Fraction) ? double.Parse(entity.Fraction).ToString() : "0";
                    entity.SingleQuantity = !string.IsNullOrEmpty(entity.SingleQuantity) ? int.Parse(entity.SingleQuantity).ToString() : "0";
                    entity.ScoreScore = !string.IsNullOrEmpty(entity.ScoreScore) ? double.Parse(entity.ScoreScore).ToString() : "0";
                    entity.MultipleQuantity = !string.IsNullOrEmpty(entity.MultipleQuantity) ? int.Parse(entity.MultipleQuantity).ToString() : "0";
                    entity.MultipleScore = !string.IsNullOrEmpty(entity.MultipleScore) ? double.Parse(entity.MultipleScore).ToString() : "0";
                    entity.JudgeQuantity = !string.IsNullOrEmpty(entity.JudgeQuantity) ? int.Parse(entity.JudgeQuantity).ToString() : "0";
                    entity.JudgeScore = !string.IsNullOrEmpty(entity.JudgeScore) ? double.Parse(entity.JudgeScore).ToString() : "0";
                    entity.ZHQuantity = !string.IsNullOrEmpty(entity.ZHQuantity) ? int.Parse(entity.ZHQuantity).ToString() : "0";//综合条数
                    entity.ZHScore = !string.IsNullOrEmpty(entity.ZHScore) ? double.Parse(entity.ZHScore).ToString() : "0";//综合分值
                    entity.Time = !string.IsNullOrEmpty(entity.Time) ? Int32.Parse(entity.Time).ToString() : "0";
                    entity.StartDate = entity.StartDate.ToShortDateString() == "0001/1/1" ? Convert.ToDateTime("1900-01-01") : entity.StartDate;
                    entity.EndDate = entity.EndDate.ToShortDateString() == "0001/1/1" ? Convert.ToDateTime("1900-01-01") : entity.EndDate;
                    entity.PassRatio = !string.IsNullOrEmpty(entity.PassRatio) ? Int32.Parse(entity.PassRatio).ToString() : "0";
                    entity.ZJType = "随机组卷";
                    entity.NYCD = "0";//难易程度
                    entity.SHName = "0";//审核人ID
                    entity.Frequency = !string.IsNullOrEmpty(entity.Frequency) ? double.Parse(entity.Frequency).ToString() : "0";
                    entity.isDeleted = "0";
                    entity.ZHSc = "0";
                    entity.PaperOrderBy = "orderbythree";
                    entity.CreateDate = DateTime.Now;
                    _examInfoBll.InsertExam(entity);
                }
                else //更新
                {
                    entity.StartDate = entity.StartDate.ToShortDateString() == "0001/1/1" ? Convert.ToDateTime("1900-01-01") : entity.StartDate;
                    entity.EndDate = entity.EndDate.ToShortDateString() == "0001/1/1" ? Convert.ToDateTime("1900-01-01") : entity.EndDate;
                    _examInfoBll.UpdateExam(entity);
                }
                //保存题库,先删除原来的题库再保存
                if (!string.IsNullOrEmpty(entity.Tid))
                {
                    var typeInfo = _examQuestionsBll.GetResultSearch(new ExamQuestionsEntity() { Tid = entity.Tid });
                    if (typeInfo.Any())
                    {
                        var flag = _examQuestionsBll.DeleteEexamQuestions(entity.Tid);
                    }
                    if (!string.IsNullOrEmpty(Ids))
                    {
                        string[] id = Ids.Split(',');
                        foreach (var item in id)
                        {
                            if (!string.IsNullOrEmpty(item))
                            {
                                var flag = _examQuestionsBll.InsertEexamQuestions(entity.Tid, item);
                            }
                        }
                    }

                }
                isOk = true;
            }
            catch (Exception)
            {
                isOk = false;
            }
            var result = new StatusModel<object>
            {
                rtState = isOk ? 1 : -1,
                rtData = null,
                rtObj = null,
                rtMsrg = "成功"
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 题库管理
        /// </summary>
        /// <returns></returns>
        public ActionResult QuestionBankManagement()
        {
            return View();
        }

        /// <summary>
        /// 获取试题信息
        /// </summary>
        /// <param name="keywords"></param>
        /// <param name="rows"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public string GetQuestionBankData(string keywords, int rows = 30, int page = 1)
        {
            var data = _examThemeBll.GetQuestionInfo(keywords, rows, page);
            foreach (var item in data.Items)
            {
                if (item.QuestionsType.Equals("00290001"))
                {
                    item.QuestionsType = "单选题";
                }
                if (item.QuestionsType.Equals("00290002"))
                {
                    item.QuestionsType = "多选题";
                }
                if (item.QuestionsType.Equals("00290003"))
                {
                    item.QuestionsType = "判断题";
                }
                if (item.QuestionsType.Equals("00290004"))
                {
                    item.QuestionsType = "分析题";
                }
                if (item.QuestionsType.Equals("00290005"))
                {
                    item.QuestionsType = "作文题";
                }
                if (item.QuestionsType.Equals("00290006"))
                {
                    item.QuestionsType = "论述题";
                }
                if (item.QuestionsType.Equals("00290007"))
                {
                    item.QuestionsType = "填空题";
                }
                if (item.QuestionsType.Equals("00290008"))
                {
                    item.QuestionsType = "简答题";
                }
                if (item.QuestionsType.Equals("00290009"))
                {
                    item.QuestionsType = "综合题";
                }
                if (item.QuestionsType.Equals("00290010"))
                {
                    item.QuestionsType = "操作题";
                }
            }
            var result = CommonMethod.PageToJson(CommonMethod.PageToJqGridPage(data));
            return result;
        }

        /// <summary>
        /// 添加题库
        /// </summary>
        /// <returns></returns>
        public ActionResult SubInsertTitle()
        {
            var entity = new ExamTypeEntity();
            return View(entity);
        }

        /// <summary>
        /// 添加题库
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="collection"></param>
        /// <returns></returns>
        public JsonResult TitleData(ExamTypeEntity entity, FormCollection collection)
        {
            var isOk = false;
            try
            {
                if (!string.IsNullOrEmpty(entity.SubJectId)) //新增
                {
                    entity.SubJectId = Guid.NewGuid().ToString();
                    entity.SubJectRadio = "0";
                    entity.SubJectDuo = "0";
                    entity.SubJectPan = "0";
                    entity.SubjectIsStart = "1";
                    entity.CreateDate = DateTime.Now;
                    entity.QuetionID = "0";
                    if (!string.IsNullOrEmpty(entity.SubJectId) && !string.IsNullOrEmpty(entity.SubJectName))
                    {
                        var flag = _examTypeBll.InsertEaxamType(entity);
                    }
                }
                isOk = true;
            }
            catch (Exception)
            {
                isOk = false;
            }
            var result = new StatusModel<object>
            {
                rtState = isOk ? 1 : -1,
                rtData = null,
                rtObj = null,
                rtMsrg = "成功"
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 试题题库
        /// </summary>
        /// <returns></returns>
        public ActionResult SubInsertTheme(string Id)
        {
            var flag = false;
            bool dan = false, duo = false, pan = false, tian = false, other = false;
            var IsShow = false;
            var examThemeEntity = new ExamThemeEntity();
            string content = "";
            if (!string.IsNullOrEmpty(Id))
            {
                var examTheme = _examThemeBll.GetExamThemeList(new ExamThemeEntity { TItemId = Id });
                if (examTheme.Any())
                {
                    examThemeEntity = examTheme[0];
                    content = examThemeEntity.Answer;
                    if (examThemeEntity.QuestionsType == "00290007")
                    {
                        string[] con = examThemeEntity.Answer.Split('&');
                        ViewBag.Tian = con;
                        flag = true;
                        tian = true;
                    }
                    IsShow = true;
                    if (examThemeEntity.QuestionsType == "00290001")
                    {
                        dan = true;
                    }
                    if (examThemeEntity.QuestionsType == "00290002")
                    {
                        duo = true;
                    }
                    if (examThemeEntity.QuestionsType == "00290003")
                    {
                        pan = true;
                    }
                    if (examThemeEntity.QuestionsType == "00290004" || examThemeEntity.QuestionsType == "00290005" || examThemeEntity.QuestionsType == "00290006" || examThemeEntity.QuestionsType == "00290008")
                    {
                        other = true;
                    }

                }
            }
            ViewBag.dan = dan;
            ViewBag.duo = duo;
            ViewBag.pan = pan;
            ViewBag.Istian = tian;
            ViewBag.other = other;

            ViewBag.IsShow = IsShow;

            ViewBag.Answer = content;
            ViewBag.Flag = flag;

            //试题题库类型
            var source = _quetionTypeBll.GetQuestionTypeList();
            ViewData["Sources"] = source;
            //题库类型
            var examsource = _examTypeBll.GetExamList(new ExamTypeEntity());
            ViewData["ExamSources"] = new SelectList(examsource, "SubJectId", "SubJectName");
            //试题类型
            //var questionTypeList = EnumOperate.ConvertEnumToListItems(typeof(QuestionType), "0");
            //ViewData["QuestionType"] = questionTypeList;
            var questionTypeList = new List<ExamEnumEntity>();
            questionTypeList.Insert(0, new ExamEnumEntity { Id = "0", RsKey = "---请选择---" });
            questionTypeList.Insert(1, new ExamEnumEntity { Id = "00290001", RsKey = "单选题" });
            questionTypeList.Insert(2, new ExamEnumEntity { Id = "00290002", RsKey = "多选题" });
            questionTypeList.Insert(3, new ExamEnumEntity { Id = "00290003", RsKey = "判断题" });
            questionTypeList.Insert(4, new ExamEnumEntity { Id = "00290004", RsKey = "分析题" });
            questionTypeList.Insert(5, new ExamEnumEntity { Id = "00290005", RsKey = "作文题" });
            questionTypeList.Insert(6, new ExamEnumEntity { Id = "00290006", RsKey = "论述题" });
            questionTypeList.Insert(7, new ExamEnumEntity { Id = "00290007", RsKey = "填空题" });
            questionTypeList.Insert(8, new ExamEnumEntity { Id = "00290008", RsKey = "简答题" });
            ViewData["QuestionType"] = new SelectList(questionTypeList, "Id", "RsKey");
            //难易度
            //var difficulty = EnumOperate.ConvertEnumToListItems(typeof(Difficulty), "0");
            //ViewData["Difficulty"] = difficulty;
            var difficulty = new List<ExamEnumEntity>();
            difficulty.Insert(0, new ExamEnumEntity { Id = "0", RsKey = "---请选择---" });
            difficulty.Insert(1, new ExamEnumEntity { Id = "001", RsKey = "难" });
            difficulty.Insert(2, new ExamEnumEntity { Id = "002", RsKey = "较难" });
            difficulty.Insert(3, new ExamEnumEntity { Id = "003", RsKey = "中等" });
            difficulty.Insert(4, new ExamEnumEntity { Id = "004", RsKey = "较易" });
            difficulty.Insert(5, new ExamEnumEntity { Id = "005", RsKey = "容易" });
            ViewData["Difficulty"] = new SelectList(difficulty, "Id", "RsKey"); ;

            string Str = "";
            if (!string.IsNullOrEmpty(Id))
            {
                //选中的试题类型
                var typeInfo = _quetionTitleBll.GetResultSearch(new QuetionTitleEntity() { TItemId = Id });
                if (typeInfo.Any())
                {
                    foreach (var item in typeInfo)
                    {
                        Str += item.QuetionID + ",";
                    }
                }
            }
            ViewBag.ChkType = Str;
            return View(examThemeEntity);
        }

        /// <summary>
        /// 提交试题
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="collection"></param>
        /// <returns></returns>
        public JsonResult FormalExamTheme(ExamThemeEntity entity, string para, FormCollection collection)
        {
            var isOk = false;
            try
            {
                string[] s = para.Split('|');
                //保存试题
                if (string.IsNullOrEmpty(entity.TItemId)) //新增
                {
                    entity.TItemId = Guid.NewGuid().ToString();
                    entity.Answer = s[1];
                    entity.IsDeleted = "0";
                    entity.DeptID = "";
                    entity.CreateBy = "";
                    entity.CreateDate = DateTime.Now;
                    _examThemeBll.InsertExamTheme(entity);
                }
                else //更新
                {
                    entity.Answer = s[1];
                    _examThemeBll.UpdateExamTheme(entity);
                }
                //保存题库,先删除原来的题库再保存
                if (!string.IsNullOrEmpty(entity.TItemId))
                {
                    var typeInfo = _quetionTitleBll.GetResultSearch(new QuetionTitleEntity() { TItemId = entity.TItemId });
                    if (typeInfo.Any())
                    {
                        var flag = _quetionTitleBll.DeleteQuetionTitleTheme(entity.TItemId);
                    }
                    if (!string.IsNullOrEmpty(s[0]))
                    {
                        string[] id = s[0].Split(',');
                        foreach (var item in id)
                        {
                            if (!string.IsNullOrEmpty(item))
                            {
                                var flag = _quetionTitleBll.InsertQuetionTitleTheme(item, entity.TItemId, entity.QuestionsType);
                            }
                        }
                    }

                }
                isOk = true;
            }
            catch (Exception)
            {
                isOk = false;
            }
            var result = new StatusModel<object>
            {
                rtState = isOk ? 1 : -1,
                rtData = null,
                rtObj = null,
                rtMsrg = "成功"
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 删除试题
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public string DeleteExamTheme(string id)
        {
            string rtMsrg;
            int rtState;
            try
            {
                var flag = _examThemeBll.DeleteExamTheme(id);
                rtMsrg = flag ? "删除成功" : "删除失败";
                rtState = flag ? (int)OperationState.Success : (int)OperationState.Failure;
            }
            catch (Exception ex)
            {
                rtState = (int)OperationState.Error;
                rtMsrg = ex.Message;
            }
            var rtEntity = new StatusModel<DBNull>
            {
                rtData = null,
                rtMsrg = rtMsrg,
                rtState = rtState
            };
            return CommonMethod.ToJson(rtEntity);
        }

        /// <summary>
        /// 个人成绩统计
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        public ActionResult PersonalAchievementStatistics()
        {
            string userId = CurrentUser.CrmUser.Id;
            if (!string.IsNullOrEmpty(userId))
            {
                ViewBag.Id = userId;
            }
            return View();
        }

        /// <summary>
        /// 获取考试成绩
        /// </summary>
        /// <param name="keywords"></param>
        /// <param name="rows"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public string GetPersonalInfomationData(string keywords, string userId, int rows, int page, string sidx, string sord)
        {
            var data = _examInfoBll.QueryExamInfo(keywords, userId, "正式考试", sidx, sord, rows, page);
            var timeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy'-'MM'-'dd" };
            var dtSourse = data.rows as DataTable;
            for (int i = dtSourse.Rows.Count - 1; i >= 0; i--)
            {
                var userExamList = _examInfoMationBll.GetSearchResult(new ExamInfoMationEntity { Uid = userId, Tid = dtSourse.Rows[i]["Tid"].ToString() });
                if (!userExamList.Any())
                {
                    dtSourse.Rows.Remove(dtSourse.Rows[i]);
                }
                else
                {
                    if (dtSourse.Rows[i]["Frequency"].ToString() != "0")
                    {
                        dtSourse.Rows[i]["isMarking"] = (Convert.ToInt32(dtSourse.Rows[i]["Frequency"]) - userExamList.Count) > 0 ? Convert.ToInt32(dtSourse.Rows[i]["Frequency"]) - userExamList.Count : 0;
                    }
                }
            }
            var result = JsonConvert.SerializeObject(data, timeConverter);
            return result;
        }

        //正式考试成绩
        public ActionResult FormalExamInfomations(string Id)
        {
            if (!string.IsNullOrEmpty(Id))
            {
                ViewBag.Id = Id;
            }
            return View();
        }

        /// <summary>
        /// 获取考试成绩
        /// </summary>
        /// <param name="keywords"></param>
        /// <param name="rows"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public string GetFormalInfomationData(string keywords, string Tid, int rows = 30, int page = 1)
        {
            string userId = CurrentUser.CrmUser.Id;
            var data = _examInfoMationBll.GetExamInfomation(keywords, Tid, userId, rows, page);
            if (data.Items.Count > 0)
            {
                foreach (var item in data.Items)
                {
                    if (!string.IsNullOrEmpty(item.Tid))
                    {
                        var lst = _examInfoBll.GetExamInfoList(new ExamInfoEntity() { Tid = item.Tid });
                        if (lst.Any())
                        {
                            item.ExamTitle = lst[0].Title;
                            item.ExamScore = lst[0].Fraction;
                        }
                    }
                }
            }
            if (!string.IsNullOrEmpty(keywords))
            {
                for (int i = 0; i < data.Items.Count; i++)
                {
                    if (!data.Items[i].ExamTitle.Contains(keywords))
                    {
                        data.Items.Remove(data.Items[i]);
                        i--;
                    }
                }
            }
            var result = CommonMethod.PageToJson(CommonMethod.PageToJqGridPage(data));
            return result;
        }
    }
}
