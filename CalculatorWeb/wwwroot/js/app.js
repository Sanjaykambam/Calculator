(function(){
  const opEl = document.getElementById('op');
  const aEl = document.getElementById('a');
  const bEl = document.getElementById('b');
  const compute = document.getElementById('compute');
  const clear = document.getElementById('clear');
  const msg = document.getElementById('message');
  const resultEl = document.getElementById('result');

  function showMessage(text){ msg.textContent = text; }
  function showResult(val){ resultEl.textContent = '= ' + val; }
  function clearDisplay(){ msg.textContent=''; resultEl.textContent=''; }

  function parseNumber(s){
    const n = Number(s);
    return Number.isFinite(n) ? n : null;
  }

  function computeOp(){
    clearDisplay();
    const a = parseNumber(aEl.value.trim());
    const b = parseNumber(bEl.value.trim());
    if (a === null) { showMessage('Invalid number A'); return; }
    if (b === null) { showMessage('Invalid number B'); return; }

    const op = opEl.value;
    try{
      let r;
      switch(op){
        case 'add': r = a + b; break;
        case 'sub': r = a - b; break;
        case 'mul': r = a * b; break;
        case 'div':
          if (b === 0) throw new Error('Cannot divide by zero');
          r = a / b; break;
        default: throw new Error('Unknown operation');
      }
      showResult(r);
    }catch(e){ showMessage(e.message || String(e)); }
  }

  compute.addEventListener('click', computeOp);
  clear.addEventListener('click', ()=>{ aEl.value=''; bEl.value=''; clearDisplay(); });

})();
