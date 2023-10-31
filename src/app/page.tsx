import Home from "./[locale]/page";

export default function Page({ params: {locale} }: { params: any }) {
  return (
    <>
      <Home params={locale} />
    </>
  )
}
