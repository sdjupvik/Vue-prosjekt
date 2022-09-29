import{d as b,u as _,i as v,n as u,o as g,s as h,a as r,c as d,f as e,w as l,v as i,b as o,z as y,F as w,r as x,q as k,j as N,g as V,l as U,x as M,t as S}from"./index.36a69966.js";const j=["onSubmit"],B={class:"d-block d-md-flex justify-content-md-between"},C={class:"form-group"},D=e("label",{for:"firstname"},"Name",-1),T={class:"form-group"},W=e("label",{for:"rank"},"Weapon type",-1),q=["value"],F={class:"form-group mt-3"},L=e("label",{for:"address"},"Description",-1),R={class:"d-block d-md-flex justify-content-md-between mt-3"},$={class:"form-group"},z={class:"form-check"},E=e("label",{class:"form-check-labe",for:"special"},[V(" this is a nuclear weapon "),e("i",{class:"bi bi-radioactive bg-army-200 p-1 rounded"})],-1),G={class:"d-block d-md-flex justify-content-md-between my-3"},I={class:"form-group"},K=e("label",{for:"mass"},"Mass (in Kg)",-1),P={class:"form-group"},A=e("label",{for:"length"},"Length (in mm)",-1),H={class:"form-group"},J=e("label",{for:"range"},"Range (in m)",-1),O=U('<button class="btn btn-sm me-3 mt-3 mb-5 sans" type="reset"><i class="bi bi-x-square-fill"></i> Clear </button><button class="btn btn-sm btn-army-500 mt-3 mb-5 me-1"><i class="bi bi-save"></i><span class="ms-2">Update</span></button>',2),Y=b({setup(Q){const p=_();let s=v({name:"",description:"",isNuclear:!1,range:0,length:0,mass:0,type:0}),m=Number(u.currentRoute.value.params.id);g(async()=>{let n=await h(`weapon/${m}`);s.value.name=n.name,s.value.type=n.weaponType.id,s.value.description=n.description,s.value.isNuclear=n.isNuclear,s.value.mass=n.mass,s.value.length=n.length,s.value.range=n.range});async function f(){await M(`weapon/${m}`,s.value),u.push("/weapons")}return(n,a)=>{var c;return r(),d("form",{class:"text-army-500 custom-class",onSubmit:N(f,["prevent"])},[e("div",B,[e("div",C,[D,l(e("input",{class:"form-control",id:"firstname","onUpdate:modelValue":a[0]||(a[0]=t=>o(s).name=t)},null,512),[[i,o(s).name]])]),e("div",T,[W,l(e("select",{class:"form-select","onUpdate:modelValue":a[1]||(a[1]=t=>o(s).type=t)},[(r(!0),d(w,null,x((c=o(p).filters.find(t=>t.type==="weapon"))==null?void 0:c.data.filter(t=>t.id),t=>(r(),d("option",{value:t.id},S(t.name),9,q))),256))],512),[[y,o(s).type]])])]),e("div",F,[L,l(e("textarea",{class:"form-control",id:"address",rows:"3","onUpdate:modelValue":a[2]||(a[2]=t=>o(s).description=t)},null,512),[[i,o(s).description]])]),e("div",R,[e("div",$,[e("div",z,[l(e("input",{class:"form-check-input",type:"checkbox",id:"special","onUpdate:modelValue":a[3]||(a[3]=t=>o(s).isNuclear=t)},null,512),[[k,o(s).isNuclear]]),E])])]),e("div",G,[e("div",I,[K,l(e("input",{type:"number",class:"form-control",id:"mass","onUpdate:modelValue":a[4]||(a[4]=t=>o(s).mass=t),min:"1"},null,512),[[i,o(s).mass]])]),e("div",P,[A,l(e("input",{type:"number",class:"form-control",id:"length","onUpdate:modelValue":a[5]||(a[5]=t=>o(s).length=t),min:"1"},null,512),[[i,o(s).length]])]),e("div",H,[J,l(e("input",{type:"number",class:"form-control",id:"range","onUpdate:modelValue":a[6]||(a[6]=t=>o(s).range=t),min:"1"},null,512),[[i,o(s).range]])])]),O],40,j)}}});export{Y as default};
