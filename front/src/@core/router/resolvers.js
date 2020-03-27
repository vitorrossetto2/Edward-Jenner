const resolveUser = async () => {
  return new Promise((resolve) => {
    window.spinner?.show(true);
    setTimeout(() => {
      resolve({ user: 'Luis Paulo' });
      window.spinner.show(false);
    }, 6000);
  });
};

export { resolveUser };
